using System.IO;
using Microsoft.Data.Sqlite;

namespace BookLibrary.Other
{
    public static class DatabaseOperations
    {
        private const string dbName = "book_library.db";

        public static void CheckDatabase()
        {
            if (!File.Exists(dbName)) DatabaseOperations.CreateDatabase();
            else
            {
                using (var connection = new SqliteConnection("Data Source=" + dbName))
                {
                    connection.Open();
                    //TODO Sprawdzenie struktury bazy danych
                    connection.Close();
                }
            }
        }

        public static void CreateDatabase()
        {
            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE author (id INTEGER PRIMARY KEY, name TEXT, timestamp INTEGER);
                    CREATE TABLE book (id INTEGER PRIMARY KEY, name TEXT, year INTEGER, timestamp INTEGER);
                ";
                command.ExecuteNonQuery();
            }

            DatabaseOperations.FillSampleData();
        }

        public static void DatabaseSync()
        {

        }

        private static void FillSampleData()
        {
            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();

                var command = connection.CreateCommand();
                /*command.CommandText =
                @"
                    CREATE TABLE author (name varchar(20));
                    
                ";
                command.ExecuteNonQuery();*/
            }
        }
    }
}
