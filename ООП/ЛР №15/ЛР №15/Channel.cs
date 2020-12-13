using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР__15
{
    class Channel
    {
        private int id = 0;
        public string Name { get; }
        public int ID { get; }
        public bool Used { get; set; } = false;
        public string? UserName { get; set; } = null;
        public Channel(string name)
        {
            Name = name;
            ID = id++;
        }
    }
}
