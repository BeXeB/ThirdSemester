using HouseManagerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    class ChatService : IChatService
    {
        private static readonly IDBChatMessage dBChat = new DBChatMessage();
        private static readonly IDBSession dBSession = new DBSession();
        public List<ChatMessage> GetChatMessages(int houseid)
        {
            List<HouseManagerServer.ChatMessage> serverlist = dBChat.GetAllChatMessageInHouse(houseid);
            List<ChatMessage> list = new List<ChatMessage>();
            foreach (var item in serverlist)
            {
                list.Add(new ChatMessage { Id = item.Id, Message = item.Message, SendDate = item.SendDate, Sender = new Person { UserName = item.Sender.UserName } });
            }
            return list;
        }

        public bool SendMessage(ChatMessage message, int houseid, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            return dBChat.InsertMessage(new HouseManagerServer.ChatMessage { Message = message.Message, SendDate = message.SendDate, Sender = person }, houseid);
        }
    }
}
