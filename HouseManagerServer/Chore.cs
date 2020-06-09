using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class Chore
    {
        public int Id { get; set; }
        public byte Status { get; set; }
        public Person Person { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
    }
}
