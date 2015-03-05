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

        [DataMember]
        public int hp { get; set; }

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

        [DataMember]
        public bool IsInjury { get; set; }
    }
}

