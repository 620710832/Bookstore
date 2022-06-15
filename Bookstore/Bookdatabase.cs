using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    internal class Bookdatabase
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Book_Detail_Table (IBNS INTEGER PRIMARY KEY, " +
                    "Book_name NVARCHAR(20) NULL," +
                    "Price NVARCHAR(20) NULL," +
                    "Biller NVARCHAR(20) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        public  void AddData(string book_name, string price,string biller)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Book_Detail_Table VALUES (NULL, @bookname,@price,@biller);";
                insertCommand.Parameters.AddWithValue("@bookname", book_name);
                insertCommand.Parameters.AddWithValue("@price", price);
                insertCommand.Parameters.AddWithValue("@biller", biller);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        public static List<String> Get_data()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT * from Book_Detail_Table", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }
        public static List<String> Get_data_onlyIBSN(string IBSN)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db = new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM Book_Detail_Table WHERE IBNS = '" + IBSN + "'", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }
        public static bool checkIBSN(string IBSN)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                SqliteCommand selectCommand = new SqliteCommand("SELECT IBNS from Book_Detail_Table WHERE IBNS = '" + IBSN + "'", db);
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
        public static void UpdateData(string IBSN,string bookname, string price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=Book_Detail.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "UPDATE Book_Detail_Table SET Book_name = @bookname, Price = @price WHERE IBNS = '" + IBSN + "'";
                insertCommand.Parameters.AddWithValue("@bookname", bookname);
                insertCommand.Parameters.AddWithValue("@price", price);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
    }
}
