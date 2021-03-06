﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.Models
{
    public class HouseItem
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public short Floor { get; set; }
        public string DoorNo { get; set; }
        public string InviteCode { get; set; }
        public ObservableCollection<Person> People { get; set; }
        public ObservableCollection<ChoreItem> Chores { get; set; }
        public ObservableCollection<ChatItem> Chat { get; set; }
    }
}
