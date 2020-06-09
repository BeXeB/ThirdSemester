using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public Person Sender { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
