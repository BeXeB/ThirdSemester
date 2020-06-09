using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public class MemoList
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}