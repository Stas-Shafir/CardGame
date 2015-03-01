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
        [DataMember]
        public Gamer fGamer = null;

        [DataMember]
        public Gamer tGamer = null;

        Random Rnd;

        public int Level { get; set; }

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

        public Game(Game oldGame)
        {
            this.Gamers = new List<string>(oldGame.Gamers);
            this.firstGamerCards = new List<Card>(oldGame.firstGamerCards);
            this.twoGamerCards = new List<Card>(oldGame.twoGamerCards);
            this.gameState = oldGame.gameState;
            this.currUsr = oldGame.currUsr;
            this.WinGamerReward = oldGame.WinGamerReward;
            this.LooseGamerReward = oldGame.LooseGamerReward;
        }


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
            Gamers.Add(user);
            twoGamerCards = new List<Card>(tgc);
            gameState = 2;
        }

        public bool CheckWinner()
        {
            if (firstGamerCards.FindAll(c => c.hp > 0).Count == 0
                || twoGamerCards.FindAll(c => c.hp > 0).Count == 0)
            {
                if (currUsr == Gamers[0])
                {
                    getReward(Gamers[0], true);
                    getReward(Gamers[1]);
                }
                else
                {
                    getReward(Gamers[0]);
                    getReward(Gamers[1], true);
                }
                gameState = 4;
                return true;
            }
            return false;
        }

        public void getReward(string nickname, bool isWinner = false)
        {
            Reward reward = new Reward();

            if (isWinner)
            {
                reward.Exp = Rnd.Next(245, 255);
                reward.Score = Rnd.Next(123, 133);
                if (Rnd.Next(0, 100) <= 35) //drop card %
                {
                    List<Card> clst = Program.cards.FindAll(ccc => ccc.type != 0);
                    if (clst.Count > 1)
                    {
                        reward.NewCard = clst[Rnd.Next(0, clst.Count - 1)];
                    }
                }
                WinGamerReward = reward;
            }
            else
            {
                reward.Exp = Rnd.Next(123, 133);
                reward.Score = Rnd.Next(62, 72);
                LooseGamerReward = reward;
            }
        }

    }
}
