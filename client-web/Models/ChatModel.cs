using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_web.Models
{
    public class ChatModel
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public int Id { get; set; }
        public int HouseId { get; set; }
    }
}
