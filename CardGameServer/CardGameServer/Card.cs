using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGameServer
{
    public class Card
    {
        public int id { get; set; }
        public string card_name { get; set; }
        public int hp {get; set;}
        public int dmg { get; set; }
        public int def { get; set; }

        public Card()
        {
        }

        public Card(int id, string cn, int hp, int dmg, int def)
        {
            this.id = id;
            this.card_name = cn;
            this.hp = hp;
            this.dmg = dmg;
            this.def = def;
        }
    }
}
