using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardGameServer
{
    [DataContract]
    public class Card
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string card_name { get; set; }

        public int type { get; set; }

        [DataMember]
        public int hp {get; set;}

        [DataMember]
        public int dmg { get; set; }

        [DataMember]
        public int def { get; set; }

        [DataMember]
        public int slot { get; set; }

        [DataMember]
        public bool Enabled { get; set; }

        [DataMember]
        public int cardRarity { get; set; }

        public bool Use = false;

        public Card()
        {
        }

        public Card(int id, string cn, int t, int hp, int dmg, int def, int r, int sl = -1)
        {
            this.id = id;
            this.card_name = cn;
            this.type = t;
            this.hp = hp;
            this.dmg = dmg;
            this.def = def;
            this.slot = sl;
            this.cardRarity = r;
            this.Enabled = true;
        }
    }
}
