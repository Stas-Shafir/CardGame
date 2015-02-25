﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

namespace CardGameServer
{
    public class Program
    {
        public static string connectionString;

        static bool useRemoteSQLConnetion = false;

        public static Dictionary<int, int> character_templates = new Dictionary<int,int>();
        public static List<Card> cards = new List<Card>();
        public static List<Card> template_cards = new List<Card>();

        public static List<Gamer> OnlineUsers = new List<Gamer>();
        public static List<Game> OnlineGames = new List<Game>();

        public static ReaderWriterLockSlim GameThreadLock = new ReaderWriterLockSlim();
        public static ReaderWriterLockSlim UserThreadLock = new ReaderWriterLockSlim();


        static void detectTimeout()
        {
            while (true)
            {
                UserThreadLock.EnterReadLock();
                List<Gamer> users = new List<Gamer>(OnlineUsers);
                UserThreadLock.ExitReadLock();

                foreach (var user in users)
                {
                    user.lastAcc++;

                    if (user.lastAcc > 20)
                    {
                        GameThreadLock.EnterReadLock();
                        Game game = OnlineGames.Find(g => g.Gamers.Exists(u => u == user.nick));
                        GameThreadLock.ExitReadLock();

                        bool remove = false;

                        try
                        {
                            if (game != null)
                            {
                                lock (game)
                                {
                                    game.gameState = 5;
                                    game.Gamers.Remove(user.nick);
                                    if (game.Gamers.Count == 0)
                                    {
                                        remove = true;
                                    }
                                }
                            }
                        }
                        catch { }

                        UserThreadLock.EnterWriteLock();
                        OnlineUsers.Remove(user);
                        UserThreadLock.ExitWriteLock();

                        if (remove)
                        {
                            GameThreadLock.EnterWriteLock();
                            OnlineGames.Remove(game);
                            GameThreadLock.ExitWriteLock();
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }


        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(Servicegame));

                if (useRemoteSQLConnetion)
                    connectionString = Properties.Settings.Default.avalon_dbConnectionStringWithSqlAuth;
                else
                    connectionString = Properties.Settings.Default.avalon_dbConnectionString;

                SqlConnection db_connection = new SqlConnection(Program.connectionString);

                //Load all Character Templates from DB
                db_connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM character_templates", db_connection);

                SqlDataReader res = cmd.ExecuteReader();

                while (res.Read())
                {
                    character_templates.Add((int)res["hero_card"], (int)res["first_card"]);
                }

                Console.WriteLine("INFO: Load " + character_templates.Count + " character templates from database");

                res.Close();


                //Load all Card from DB

                cmd = new SqlCommand("SELECT * FROM cards", db_connection);

                res = cmd.ExecuteReader();

                while (res.Read())
                {
                    cards.Add(new Card(
                        (int)res["id"], 
                        res["card_name"].ToString(), 
                        (int)res["type"],
                        (int)res["hp"], 
                        (int)res["dmg"], 
                        (int)res["def"]
                        ));
                }

                db_connection.Close();

                //create card Heroes Template list
                foreach (var item in character_templates.Keys)
                {
                    template_cards.Add(cards.Find(c => c.id == item));
                }           

                Console.WriteLine("INFO: Load " + cards.Count + " cards from database");

                Console.WriteLine("===============================");

                host.Open();


                Thread detectTimeoutThread = new Thread(detectTimeout) { IsBackground = true };
                detectTimeoutThread.Start();


                Uri startedUri = host.Description.Endpoints[0].Address.Uri;

                Console.WriteLine("Server started on: " + startedUri.Host + ":" + startedUri.Port);

                Console.WriteLine("===============================");

                Console.WriteLine("Press ESC to exit...");


                while (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    
                }

                host.Close();

            }
            catch(Exception exc)
            {
                Console.WriteLine("ERROR: " + exc.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
}
