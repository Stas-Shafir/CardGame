using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CardGameServer
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public List<string> Gamers;

        [DataMember]
        public List<Card> firstGamerCards;

        [DataMember]
        public List<Card> twoGamerCards;

        [DataMember]
        public int gameState;

        [DataMember]
        public string currUsr;
    }
}
