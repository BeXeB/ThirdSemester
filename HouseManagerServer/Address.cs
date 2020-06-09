using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class Address
    {
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public short FloorNo { get; set; }
        public string DoorNo { get; set; }
    }
}
