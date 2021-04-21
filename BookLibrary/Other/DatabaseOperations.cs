using System;
using System.IO;
using Microsoft.Data.Sqlite;

using System.Collections.Generic;
using System.Threading;

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
                DateTime unixEpoch = new DateTime(1970, 1, 1);
                List<string> insertsList = new List<string>();
                insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Jacek Matulewski', $timeStamp);");
                insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Peter Bell', $timeStamp);");
                insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Brent Beer', $timeStamp);");
                insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Michał Włodarczyk', $timeStamp);");
                insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Krzysztof Rychlicki-Kicior', $timeStamp);");

                connection.Open();

                var command = connection.CreateCommand();
                /*command.CommandText =
                @"
                    INSERT INTO author(name, timestamp) VALUES('Jacek Matulewski', $timeStamp);
                    INSERT INTO author(name, timestamp) VALUES('Peter Bell', $timeStamp);
                    INSERT INTO author(name, timestamp) VALUES('Brent Beer', $timeStamp);
                    INSERT INTO author(name, timestamp) VALUES('Michał Włodarczyk', $timeStamp);
                    INSERT INTO author(name, timestamp) VALUES('Krzysztof Rychlicki-Kicior', $timeStamp);
                ";
                command.Parameters.AddWithValue("$timeStamp", (DateTime.UtcNow - unixEpoch).TotalSeconds);
                command.ExecuteNonQuery();
                 */

                command.CommandText = @"INSERT INTO author(name, timestamp) VALUES('Jacek Matulewski', $timeStamp);";
                command.Parameters.AddWithValue("$timeStamp", (DateTime.UtcNow - unixEpoch).TotalSeconds);
                command.ExecuteNonQuery();

                foreach (string insert in insertsList)
                {
                    command = connection.CreateCommand();
                    command.CommandText = insert;
                    command.Parameters.AddWithValue("$timeStamp", (DateTime.UtcNow - unixEpoch).TotalSeconds);
                    command.ExecuteNonQuery();
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
