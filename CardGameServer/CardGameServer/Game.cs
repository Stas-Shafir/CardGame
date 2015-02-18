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
        public int FuLastAct = 0;
        public int SuLastAct = 0;

        [DataMember]
        public List<string> Gamers = new List<string>();

        [DataMember]
        public List<Card> firstGamerCards;

        [DataMember]
        public List<Card> twoGamerCards;

        [DataMember]
        public int gameState;

        [DataMember]
        public string currUsr;


        public Game(string user, List<Card> fgc)
        {
            Gamers.Add(user);
            currUsr = user;
            firstGamerCards = new List<Card>(fgc);
            gameState = 1;
        }

        public void AddSecondUser(string user, List<Card> tgc)
        {
            Gamers.Add(user);
            twoGamerCards = new List<Card>(tgc);
            gameState = 2;
        }

        public bool CheckWinner()
        {
            return (firstGamerCards.FindAll(c => c.hp > 0).Count == 0 
                || twoGamerCards.FindAll(c => c.hp > 0).Count == 0);
        }
    }
}
