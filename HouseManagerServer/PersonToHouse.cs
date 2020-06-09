using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class PersonToHouse
    {
        public Person Person { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }
        public bool IsOwner { get; set; }
        public int HouseId { get; set; }
    }
}
