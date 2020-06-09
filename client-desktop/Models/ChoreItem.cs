using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.Models
{
    public class ChoreItem
    {
        public string Name { get; set; }
        public StatusEnum Status { get; set; }
        public Person Person { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public enum StatusEnum : int{In_Progress = 0, Done = 1, To_Be_Done = 2}
        public int Id { get; set; }
    }
}
