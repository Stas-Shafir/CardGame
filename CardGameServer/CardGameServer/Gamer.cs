using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGameServer
{
    public class Gamer
    {
        public string login { get; set; }
        public string nick { get; set; }
        public int lastAcc { get; set; }

        public Gamer(string l)
        {
            login = l;
            nick = "";
            lastAcc = 0;
        }
    }
}
