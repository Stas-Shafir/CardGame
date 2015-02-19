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
        public int Login(string user, string pass)
        {
            //0 success
            //1 incorrect pass
            //2 already online 
            //3 hacking attempt

            if (Program.OnlineUsers.Find(u => u == user) != null)
                return 2;

            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0 ||
                pass.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return 3;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT password FROM accounts where account='" + user + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            if (res.Read())
            {
                string password = res[0].ToString();
                res.Close();
                db_connection.Close();

                if (password == pass)
                {
                    Program.OnlineUsers.Add(user);
                    return 0;
                }
                return 1;
            }

            res.Close();

            cmd = new SqlCommand("INSERT INTO accounts VALUES('" + user + "', '" + pass + "')", db_connection);

            cmd.ExecuteNonQuery();

            db_connection.Close();

            Program.OnlineUsers.Add(user);

            return 0;
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

            db_connection.Close();

            return ch;
        }

        [OperationContract]
        public Game findGame(string nickname)
        {

            //check for sqlInjection
            if (sqlInjection.Words.Any(word => nickname.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return null;

            int char_id = -1;

            List<Card> gamerCard = new List<Card>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT id FROM characters where name='" + nickname + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            if (res.Read())
            {
                char_id = (int)res["id"];
                res.Close();

                cmd = new SqlCommand("SELECT card_id, slot FROM character_cards where char_id=" + char_id + 
                    " AND slot >= 0", db_connection);

                res = cmd.ExecuteReader();

                while (res.Read())
                {
                    Card currcard = Program.cards.Find(ccc => ccc.id == (int)res["card_id"]);

                    if (currcard != null) 
                        gamerCard.Add(new Card(currcard.id, currcard.card_name, currcard.hp, 
                            currcard.dmg, currcard.def, (int)res["slot"]));    
                }
            }
            res.Close();

            db_connection.Close();

            Game game = Program.OnlineGames.Find(g => g.gameState == 1);

            if (game != null)
            {
                game.AddSecondUser(nickname, gamerCard);
                return game;
            }

            game = new Game(nickname, gamerCard);
            Program.OnlineGames.Add(game);
            return game;
        }


        [OperationContract]
        public Game getGame(string nickname)
        {
            Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));

            if (game != null)
            {
                if (nickname == game.Gamers[0])
                    game.FuLastAct = 0;
                else game.SuLastAct = 0;
            }

            return Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));
        }

        [OperationContract]
        public void cancelSearch(string nickname)
        {
            Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));

            //TODO: finish this on client side...
            if (game != null && game.gameState == 1)
            {
                game.gameState = 7; //canceled
            }
        }
    }
}
