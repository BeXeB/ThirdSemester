using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class House
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public string InviteCode { get; set; }
        public List<PersonToHouse> People { get; set; }
        public List<ChatMessage> Chat { get; set; }
        public List<Chore> Chores { get; set; }
    }
}
