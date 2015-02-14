﻿using System;
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

            SqlConnection db_connection = new SqlConnection(Properties.Settings.Default.avalon_dbConnectionString);

            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT password FROM accounts where account='" + user + "'", db_connection);

            SqlDataReader res = cmd.ExecuteReader();

            if (res.HasRows)
            {
                string password = res.GetSqlString(0).ToString();
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

            SqlConnection db_connection = new SqlConnection(Properties.Settings.Default.avalon_dbConnectionString);

            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT account FROM characters where account='" + user + "'", db_connection);

            bool contains = cmd.ExecuteNonQuery() >= 1;

            db_connection.Close();

            return contains;
        }

        [OperationContract]
        public bool createCharacter(string user, string name, int heroCardId)
        {
            //check for sqlInjection
            if (sqlInjection.Words.Any(word => user.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0
                || name.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)) return false;

            SqlConnection db_connection = new SqlConnection(Properties.Settings.Default.avalon_dbConnectionString);
            db_connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT name FROM characters where name='" + user + "'", db_connection);
            bool exists = cmd.ExecuteNonQuery() >= 1;

            if (exists)
            {
                db_connection.Close();
                return false;
            }

            cmd = new SqlCommand("INSERT INTO characters(account, name) VALUES('" + user + "', '" + name + "')", db_connection);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT id FROM characters where name='" + name + "'", db_connection);
            SqlDataReader rd = cmd.ExecuteReader();
            SqlInt32 char_id = rd.GetSqlInt32(0);
            rd.Close();

            cmd = new SqlCommand("INSERT INTO character_cards(char_id, card_id, slot) VALUES" +
                    "(" + char_id + ", " + heroCardId + ", 0)", db_connection);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("INSERT INTO character_cards(char_id, card_id, slot) VALUES" +
                    "(" + char_id + ", " + Program.character_templates[heroCardId] + ", 1)", db_connection);
            cmd.ExecuteNonQuery();

            db_connection.Close();

            return true;
        }
    }
}