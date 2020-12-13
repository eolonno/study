using System;
using System.Collections.Generic;
using System.Text;

namespace ЛР__15
{
    class User
    {
        private int id = 0;
        public string Name { get; }
        public int ID { get; }
        public User(string name)
        {
            Name = name;
            ID = id++;
        }
    }
}
