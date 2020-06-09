﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_desktop.Models
{
    public class ChatItem
    {
        public Person Author { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
        public int Id { get; set; }
    }
}
