using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    internal class CustomerDatabase
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS login_Table (uid INTEGER PRIMARY KEY, " +
                    "Name NVARCHAR(20) NULL," +
                    "Address NVARCHAR(200) NULL," +
                    "Email NVARCHAR(20) NULL," +
                    "password NVARCHA(20) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        public static void AddData(string cus_name,string cus_email,string cus_address,string cus_password)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO login_Table VALUES (NULL, @name,@address,@email,@password);";
                insertCommand.Parameters.AddWithValue("@name",cus_name);
                insertCommand.Parameters.AddWithValue("@address", cus_address);
                insertCommand.Parameters.AddWithValue("@email", cus_email);
                insertCommand.Parameters.AddWithValue("@password", cus_password);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT name from login_Table", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                db.Close();
            }
            return entries;
        }
        public static List<String> Getuser_password(String cus_email)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT * from login_Table WHERE Email = '" + cus_email + "'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                    entries.Add(query.GetString(4));
                }
                db.Close();
            }
            return entries;
        }
        public static void UpdateData(string cus_name, string cus_email, string cus_address, string cus_password,string id)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "UPDATE login_Table SET Name = @name, Address = @address, Email = @email, password = @password WHERE uid = '" + id + "'";
                insertCommand.Parameters.AddWithValue("@name", cus_name);
                insertCommand.Parameters.AddWithValue("@address", cus_address);
                insertCommand.Parameters.AddWithValue("@email", cus_email);
                insertCommand.Parameters.AddWithValue("@password", cus_password);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        public static List<String> Get_Detail(String UID)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT * from login_Table WHERE uid = '" + UID + "'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                    entries.Add(query.GetString(4));
                }
                db.Close();
            }
            return entries;
        }
        public static bool checkemail(string cus_email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT Email from login_Table WHERE Email = '" + cus_email + "'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                int count = 0;
                while (query.Read())
                {
                    count++;
                }
                if (count > 0 )
                {
                    return false;
                }
                return true;
            }
        }
        public static void DeleteData(string UID)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "DELETE FROM login_Table ";
                insertCommand.Parameters.AddWithValue("@uid", UID);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        public static bool checknull(string cus_email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Customer_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT Email from login_Table WHERE Email = '" + cus_email + "'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                int count = 0;
                while (query.Read())
                {
                    count++;
                }
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

    }
}
