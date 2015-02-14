﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CardGameServer
{
    public class Program
    {
        public static Dictionary<int, int> character_templates = new Dictionary<int,int>();
        public static List<Card> cards = new List<Card>();

        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(Servicegame));

                SqlConnection db_connection = new SqlConnection(Properties.Settings.Default.avalon_dbConnectionString);

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
                        (int)res["hp"], 
                        (int)res["dmg"], 
                        (int)res["def"]
                        ));
                }

                db_connection.Close();


                Console.WriteLine("INFO: Load " + cards.Count + " cards from database");

                Console.WriteLine("===============================");

                host.Open();

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