﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.SqlClient;

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

        [DataMember]
        public bool IsInjury { get; set; } //effect

        public bool Use = false;

        public int min_level = 1;

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
            this.IsInjury = false;
        }

        public void TryEnjured()
        {
            if (!IsInjury && Program.Rnd.Next(0, 3) == 1) //Injury effect
            {
                IsInjury = true;
                dmg -= (int)(dmg * 0.3);
            }
        }
        

        public static List<Card> GetAllavailableCards(string user)
        {
            int char_level = 1;
            List<Card> tmp = new List<Card>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT character_level FROM characters where account='" + user + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                if (res.Read())
                {
                    char_level = (int)res["character_level"];
                    res.Close();

                    tmp = Program.cards.FindAll(ccc => ccc.type != 0 && ccc.min_level <= char_level);

                }
                else res.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message + "\r\n" + exc.StackTrace);
                Program.dumpException(exc);
            }

            db_connection.Close();

            return tmp;
            
        }


        public static List<Card> GetAllavailableCardsByNickName(string nickname)
        {
            int char_level = 1;
            List<Card> tmp = new List<Card>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT character_level FROM characters where name='" + nickname + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                if (res.Read())
                {
                    char_level = (int)res["character_level"];
                    res.Close();

                    tmp = Program.cards.FindAll(ccc => ccc.type != 0 && ccc.min_level <= char_level);

                }
                else res.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message + "\r\n" + exc.StackTrace);
                Program.dumpException(exc);
            }

            db_connection.Close();

            return tmp;

        }
    }
}
