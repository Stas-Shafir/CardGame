using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using CardGameServer.Security;

namespace CardGameServer
{
    [ServiceContract]
    public class Servicegame
    {
        [OperationContract]
        public bool Login(string user, string pass)
        {
            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0 ||
                pass.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return false;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT password FROM accounts where account='" + user + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            if (res.Read())
            {
                string password = res[0].ToString();
                res.Close();
                db_connection.Close();

                if (password == pass) return true;
                return false;
            }

            res.Close();

            cmd = new SqlCommand("INSERT INTO accounts VALUES('" + user + "', '" + pass + "')", db_connection);

            cmd.ExecuteNonQuery();

            db_connection.Close();

            return true;
        }

        [OperationContract]
        public bool isAccountContainsAnyCharacter(string user)
        {
            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return false;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT account FROM characters where account='" + user + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            bool contains = res.Read();

            res.Close();

            db_connection.Close();

            return contains;
        }

        [OperationContract]
        public bool createCharacter(string user, string name, int heroCardId)
        {
            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0
                || name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return false;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT name FROM characters where name='" + name + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            bool exists = res.Read();

            res.Close();

            if (exists)
            {
                db_connection.Close();
                return false;
            }

            Card card = Program.cards.Find(c => c.id == heroCardId);

            cmd = new SqlCommand("INSERT INTO characters(account, name, hero_name) VALUES('" + user + "', '" + name + "', '"
                    +  card.card_name + "')", db_connection);
            //cmd = new SqlCommand("INSERT INTO characters(account, name) VALUES('" + user + "', '" + name + "')", db_connection);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT id FROM characters where name='" + name + "'", db_connection);
            res = cmd.ExecuteReader();

            if (res.Read())
            {
                int char_id = (int)res[0];
                res.Close();

                cmd = new SqlCommand("INSERT INTO character_cards(char_id, card_id, slot) VALUES" +
                        "(" + char_id + ", " + heroCardId + ", 0)", db_connection);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("INSERT INTO character_cards(char_id, card_id, slot) VALUES" +
                        "(" + char_id + ", " + Program.character_templates[heroCardId] + ", 1)", db_connection);
                cmd.ExecuteNonQuery();
            }
            else
            {
                res.Close();
                return false;
            }

            db_connection.Close();

            return true;
        }

        [OperationContract]
        public List<Card> getHeroesTemplateAvailableList()
        {
            return Program.template_cards;
        }

        [OperationContract]
        public CharInfo EnterWorld(string user)
        {
            CharInfo chInfo = null;
            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
                return chInfo;


            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM characters where account='" + user + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            if (res.Read())
            {
                chInfo = new CharInfo(res["name"].ToString(), res["hero_name"].ToString(), (int)res["character_level"],
                            (int)res["exp"], (int)res["games"], (int)res["wins"]);
            }
                
            res.Close();

            db_connection.Close();

            return chInfo;
        }


        [OperationContract]
        public List<CharInfo> getRanking()
        {
            List<CharInfo> ch = new List<CharInfo>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM characters ORDER BY character_level DESC, wins, games", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            while (res.Read())
            {
                ch.Add(new CharInfo(res["name"].ToString(), res["hero_name"].ToString(), (int)res["character_level"],
                            (int)res["exp"], (int)res["games"], (int)res["wins"]));
            }

            res.Close();

            ch.AddRange(ch);

            db_connection.Close();

            return ch;
        }
    }
}
