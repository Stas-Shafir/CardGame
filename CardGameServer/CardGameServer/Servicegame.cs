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
            bool isError = false;

            //0 success
            //1 incorrect pass
            //2 already online 
            //3 hacking attempt

            Program.UserThreadLock.EnterReadLock();
            Gamer gamer = Program.OnlineUsers.Find(u => u.login == user);
            Program.UserThreadLock.ExitReadLock();

            if (gamer != null)
                return 2;


            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0 ||
                pass.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return 3;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);   
         
            try
            {
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
                        Program.UserThreadLock.EnterWriteLock();
                        Program.OnlineUsers.Add(new Gamer(user));
                        Program.UserThreadLock.ExitWriteLock();
                        return 0;
                    }
                    return 1;
                }

                res.Close();

                cmd = new SqlCommand("INSERT INTO accounts VALUES('" + user + "', '" + pass + "')", db_connection);

                cmd.ExecuteNonQuery();
            }

            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
                isError = true;
            }

            db_connection.Close();

            if (!isError)
            {
                Program.UserThreadLock.EnterWriteLock();
                Program.OnlineUsers.Add(new Gamer(user));
                Program.UserThreadLock.ExitWriteLock();
                return 0;
            }
            else return 4;
        }

        [OperationContract]
        public bool isAccountContainsAnyCharacter(string user)
        {
            bool contains = true;

            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return false;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT account FROM characters where account='" + user + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                contains = res.Read();

                res.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

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

            try
            {
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
                        + card.card_name + "')", db_connection);
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
                    db_connection.Close();
                    return false;
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
                db_connection.Close();
                return false;
            }

            db_connection.Close();

            return true;
        }

        [OperationContract]
        public List<Card> getHeroesTemplateAvailableList()
        {
            try
            {
                return Program.template_cards;
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
                return new List<Card>();
            }
        }

        [OperationContract]
        public CharInfo EnterWorld(string user)
        {
            CharInfo chInfo = null;

            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0))
                return chInfo;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM characters where account='" + user + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                if (res.Read())
                {
                    chInfo = new CharInfo(res["name"].ToString(), res["hero_name"].ToString(), (int)res["character_level"],
                                (int)res["exp"], (int)res["games"], (int)res["wins"]);
                }

                res.Close();

                Program.UserThreadLock.EnterReadLock();
                Gamer gamer = Program.OnlineUsers.Find(u => u.login == user);
                Program.UserThreadLock.ExitReadLock();
                if (gamer != null) gamer.nick = chInfo.nickname;

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }
            
            db_connection.Close();

            return chInfo;
        }

        [OperationContract]
        public void iAmOnline(string user)
        {
            Program.UserThreadLock.EnterReadLock();
            Gamer gamer = Program.OnlineUsers.Find(u => u.login == user);
            Program.UserThreadLock.ExitReadLock();
            if (gamer != null) gamer.lastAcc = 0;
        }


        [OperationContract]
        public List<CharInfo> getRanking()
        {
            List<CharInfo> ch = new List<CharInfo>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT TOP 10 * FROM characters ORDER BY character_level DESC, wins, games", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    ch.Add(new CharInfo(res["name"].ToString(), res["hero_name"].ToString(), (int)res["character_level"],
                                (int)res["exp"], (int)res["games"], (int)res["wins"]));
                }

                res.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

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
            Game game = null;

            bool sqlConClose = false;

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT id FROM characters where name='" + nickname + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                if (res.Read())
                {
                    char_id = (int)res["id"];
                    res.Close();

                    cmd = new SqlCommand("SELECT card_id, slot FROM character_cards where char_id=" + char_id +
                        " AND slot >= 0 AND slot <= 8", db_connection);

                    res = cmd.ExecuteReader();

                    while (res.Read())
                    {
                        Card currcard = Program.cards.Find(ccc => ccc.id == (int)res["card_id"]);

                        if (currcard != null)
                            gamerCard.Add(new Card(currcard.id, currcard.card_name, currcard.type, currcard.hp,
                                currcard.dmg, currcard.def, (int)res["slot"]));
                    }
                }
                res.Close();

                db_connection.Close();

                sqlConClose = true;

                bool find = false;

                while (!find)
                {
                    Program.GameThreadLock.EnterReadLock();

                    game = Program.OnlineGames.Find(g => g.gameState == 1);

                    Program.GameThreadLock.ExitReadLock();

                    if (game != null)
                    {
                        lock (game)
                        {
                            if (game.gameState != 1) continue;

                            game.AddSecondUser(nickname, gamerCard);

                            Program.UserThreadLock.EnterReadLock();
                            Gamer gamer2 = Program.OnlineUsers.Find(u => u.nick == nickname);
                            Program.UserThreadLock.ExitReadLock();
                            if (gamer2 != null)
                                game.tGamer = gamer2;

                            return game;
                        }
                    }
                    else find = true;
                }

                Program.UserThreadLock.EnterReadLock();
                Gamer gamer1 = Program.OnlineUsers.Find(u => u.nick == nickname);
                Program.UserThreadLock.ExitReadLock();

                game = new Game(nickname, gamerCard);
                if (gamer1 != null)
                    game.fGamer = gamer1;

                Program.GameThreadLock.EnterWriteLock();
               
                Program.OnlineGames.Add(game);

                Program.GameThreadLock.ExitWriteLock();
            }

            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);

                if (!sqlConClose) 
                    db_connection.Close();
            }


            return game;
        }


        [OperationContract]
        public Game getGame(string nickname)
        {
            Game game = null;

            try
            {
                Program.GameThreadLock.EnterReadLock();

                game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));

                Program.GameThreadLock.ExitReadLock();

                bool remove = false;

                if (game != null)
                {
                    lock (game)
                    {
                        if (nickname == game.Gamers[0])
                            game.fGamer.lastAcc = 0;
                        else game.tGamer.lastAcc = 0;


                        if (game.gameState == 4 || game.gameState == 5 || game.gameState == 7)
                        {
                            game.Gamers.Remove(nickname);
                            if (game.Gamers.Count == 0)
                            {
                                remove = true;
                            }
                        }
                    }

                    if (remove)
                    {
                        Program.GameThreadLock.EnterWriteLock();
                        Program.OnlineGames.Remove(game);
                        Program.GameThreadLock.ExitWriteLock();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

            return game;
        }

        [OperationContract]
        public bool cancelSearch(string nickname)
        {
            bool remove = false;

            try
            {
                Program.GameThreadLock.EnterReadLock();
                Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));
                Program.GameThreadLock.ExitReadLock();               

                if (game != null)
                {
                    lock (game)
                    {
                        if (game.gameState == 1)
                        {
                            game.gameState = 7; //canceled
                            remove = true;
                        }
                    }
                    if (remove)
                    {
                        //    Program.GameThreadLock.EnterWriteLock();
                        //   Program.OnlineGames.Remove(game);
                        //   Program.GameThreadLock.ExitWriteLock();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

            return remove;
        }


        [OperationContract]
        public int DoAttack(string nickname, int myslot, int enslot)
        {            
            int dmg = -1;
            try
            {
                Program.GameThreadLock.EnterReadLock();
                Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));
                Program.GameThreadLock.ExitReadLock();

                bool isWin = false;

                if (game != null)
                {
                    lock (game)
                    {
                        if (game.currUsr != nickname) return dmg;

                        if (game.gameState == 2)
                        {
                            Card myC = game.firstGamerCards.Find(cc => cc.slot == myslot);
                            Card enC = game.twoGamerCards.Find(cc => cc.slot == enslot);

                            myC.Enabled = false;

                            dmg = myC.dmg - (enC.def / 2); //calc real damage

                            int temp = enC.hp; //save curr hp                          

                            enC.hp = enC.hp - dmg;

                            if (enC.hp <= 0)
                            {
                                if (enC.hp < 0) dmg = temp; //if overhit -> change hp
                                enC.hp = 0;
                                enC.Enabled = false;
                            }


                            isWin = game.CheckWinner();

                            if (!isWin && game.firstGamerCards.Find(cc => cc.Enabled == true) == null)
                            {
                                foreach (var item in game.firstGamerCards)
                                {
                                    if (item.hp > 0) item.Enabled = true;
                                }


                                game.currUsr = game.Gamers[1];
                                game.gameState = 3;
                            }

                            else if (isWin)
                            {
                                setReward(game.Gamers[0], game.WinGamerReward, game, true);
                                setReward(game.Gamers[1], game.LooseGamerReward, game, false);
                            }
                        }
                        else if (game.gameState == 3)
                        {
                            Card myC = game.twoGamerCards.Find(cc => cc.slot == myslot);
                            Card enC = game.firstGamerCards.Find(cc => cc.slot == enslot);

                            myC.Enabled = false;

                            dmg = myC.dmg - (enC.def / 2); //calc real damage

                            int temp = enC.hp; //save curr hp                          

                            enC.hp = enC.hp - dmg;

                            if (enC.hp <= 0)
                            {
                                if (enC.hp < 0) dmg = temp; //if overhit -> change hp
                                enC.hp = 0;
                                enC.Enabled = false;
                            }

                            isWin = game.CheckWinner();

                            if (!isWin && game.twoGamerCards.Find(cc => cc.Enabled == true) == null)
                            {
                                foreach (var item in game.twoGamerCards)
                                {
                                    if (item.hp > 0) item.Enabled = true;
                                }

                                game.currUsr = game.Gamers[0];
                                game.gameState = 2;
                            }

                            else if (isWin)
                            {
                                setReward(game.Gamers[1], game.WinGamerReward, game, true);
                                setReward(game.Gamers[0], game.LooseGamerReward, game, false);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }
            return dmg;
        }

        [OperationContract]
        public void leaveGame(string nickname)
        {
            try
            {
                Program.GameThreadLock.EnterReadLock();
                Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(nickname));
                Program.GameThreadLock.ExitReadLock();

                bool remove = false;

                if (game != null)
                {
                    lock (game)
                    {
                        if (game.gameState != 4 && game.gameState != 5)
                        {
                            game.Gamers.Remove(nickname);
                            game.gameState = 5;


                            game.Gamers.Remove(nickname);
                            if (game.Gamers.Count == 0)
                            {
                                remove = true;
                            }
                        }
                    }

                    if (remove)
                    {
                        Program.GameThreadLock.EnterWriteLock();
                        Program.OnlineGames.Remove(game);
                        Program.GameThreadLock.ExitWriteLock();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }


        }

        [OperationContract]
        public void Logout(string user)
        {
            try
            {
                Program.GameThreadLock.EnterReadLock();
                Game game = Program.OnlineGames.Find(g => g.Gamers.Contains(user));
                Program.GameThreadLock.ExitReadLock();

                if (game != null) leaveGame(user);

                Program.UserThreadLock.EnterReadLock();
                Gamer gamer = Program.OnlineUsers.Find(u=>u.login == user);
                Program.UserThreadLock.ExitReadLock();

                if (gamer != null)
                {
                    Program.UserThreadLock.EnterWriteLock();
                    Program.OnlineUsers.Remove(gamer);
                    Program.UserThreadLock.ExitWriteLock();
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }
        }

        public void setReward(string nickname, Reward reward, Game game, bool Winner = false)
        {
            SqlConnection db_connection = new SqlConnection(Program.connectionString);

            try
            {
                db_connection.Open();

                int c_id;
                int level;
                int exp;
                int games;
                int wins;

                SqlCommand cmd = new SqlCommand("SELECT * FROM characters WHERE name='" + nickname + "'", db_connection);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    c_id = (int)rd["id"];
                    level = (int)rd["character_level"];
                    exp = (int)rd["exp"];
                    games = (int)rd["games"];
                    wins = (int)rd["wins"];

                    rd.Close();

                    exp += reward.Exp;

                    if (exp >= Level.Levels[level + 1])
                    {
                        reward.NewLevel = true;
                        level += 1;
                    }

                    if (Winner) wins++;

                    games++;

                    cmd = new SqlCommand("UPDATE characters SET exp=" + exp + ", character_level=" + level + ", games="
                        + games + ", wins=" + wins + " WHERE id=" + c_id, db_connection);

                    cmd.ExecuteNonQuery();


                    if (reward.NewCard != null)
                    {
                        int slot = -1;

                        if (nickname == game.Gamers[0])
                        {
                            List<Card> cList1 = game.firstGamerCards.FindAll(c => c.slot <= 8);
                            if (cList1 != null)
                                slot = cList1.Max(ccc => ccc.slot);
                        }
                        else
                        {
                            List<Card> cList2 = game.twoGamerCards.FindAll(c => c.slot <= 8);
                            if (cList2 != null)
                                slot = cList2.Max(ccc => ccc.slot);
                        }

                        if (slot == 8)
                        {
                            cmd = new SqlCommand("SELECT MAX(slot) FROM character_cards WHERE char_id=" + c_id + "", db_connection);

                            rd = cmd.ExecuteReader();

                            if (rd.Read())
                            {
                                slot = (int)rd[0];

                                if (slot < 10) slot = 10;
                            }

                            rd.Close();

                        }
                        
                        slot++;


                        cmd = new SqlCommand("INSERT INTO character_cards(char_id, card_id, slot) VALUES (" + c_id + ", "
                            + reward.NewCard.id + ", " + slot +")", db_connection);

                        cmd.ExecuteNonQuery();
                    }

                }
                else rd.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

            db_connection.Close();
        }

        [OperationContract]
        public List<Card> GetAllCard(string user)
        {
             //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return null;

            int char_id = -1;

            List<Card> gamerCard = new List<Card>();

            SqlConnection db_connection = new SqlConnection(Program.connectionString);
            try
            {
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT id FROM characters where account='" + user + "'", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                if (res.Read())
                {
                    char_id = (int)res["id"];
                    res.Close();

                    cmd = new SqlCommand("SELECT card_id, slot FROM character_cards where char_id=" + char_id +
                        " AND slot > 0", db_connection);

                    res = cmd.ExecuteReader();

                    while (res.Read())
                    {
                        Card currcard = Program.cards.Find(ccc => ccc.id == (int)res["card_id"]);

                        if (currcard != null)
                            gamerCard.Add(new Card(currcard.id, currcard.card_name, currcard.type, currcard.hp,
                                currcard.dmg, currcard.def, (int)res["slot"]));
                    }
                }
                res.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }

            db_connection.Close();

            return gamerCard;
        }

        [OperationContract]
        bool ChangeCardslot(string user, int oslot, int nSlot)
        {
            return true;
        }
    }
}
