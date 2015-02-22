﻿using System;
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

        Random Rnd;

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

        [DataMember]
        public Reward WinGamerReward { get; set; }

        [DataMember]
        public Reward LooseGamerReward { get; set; }


        public Game(string user, List<Card> fgc)
        {
            Rnd = new Random();
            Gamers.Add(user);
            currUsr = user;
            firstGamerCards = new List<Card>(fgc);
            gameState = 1;
        }

        public void AddSecondUser(string user, List<Card> tgc)
        {
            gameState = 2;
            Gamers.Add(user);
            twoGamerCards = new List<Card>(tgc);           
        }

        public bool CheckWinner()
        {
            if (firstGamerCards.FindAll(c => c.hp > 0).Count == 0
                || twoGamerCards.FindAll(c => c.hp > 0).Count == 0)
            {
                getReward(Gamers[0]);
                getReward(Gamers[1]);
                gameState = 4;
                return true;
            }
            return false;
        }

        public void getReward(string nickname)
        {
            Reward reward = new Reward();

            if (nickname == currUsr)
            {
                reward.Exp = Rnd.Next(245, 255);
                if (Rnd.Next(0, 100) <= 25)
                {
                    reward.NewCard = Program.cards[Rnd.Next(0, Program.cards.Count - 1)];
                }
                WinGamerReward = reward;
            }
            else
            {
                reward.Exp = Rnd.Next(123, 133);
                LooseGamerReward = reward;
            }
        }

    }
}
