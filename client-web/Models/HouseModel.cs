using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace client_web.Models
{
    public class HouseModel
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Name { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public short Floor { get; set; }
        public string DoorNo { get; set; }
        public string InviteCode { get; set; }
    }
}
