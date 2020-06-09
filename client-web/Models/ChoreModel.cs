using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_web.Models
{
    public class ChoreModel
    {
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public string Person { get; set; }
        public DateTime EndDate { get; set; }
        public enum StatusEnum : int { In_Progress = 0, Done = 1, To_Be_Done = 2 }
        public int Id { get; set; }
        public int HouseId { get; set; }
    }
}
