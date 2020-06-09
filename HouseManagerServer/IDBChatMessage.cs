using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBChatMessage
    {
        List<ChatMessage> GetAllChatMessageInHouse(int houseid);
        bool InsertMessage(ChatMessage message, int houseid);
        bool DeleteChatMessageByHouseId(int houseid);
    }
}
