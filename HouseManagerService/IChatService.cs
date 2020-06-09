using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    [ServiceContract]
    interface IChatService
    {
        [OperationContract]
        bool SendMessage(ChatMessage message, int houseid, string sessionid);
        [OperationContract]
        List<ChatMessage> GetChatMessages(int houseid);
    }

    [DataContract]
    public class ChatMessage
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Person Sender { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime SendDate { get; set; }
    }
}
