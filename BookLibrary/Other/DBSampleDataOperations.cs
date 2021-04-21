using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Data.Sqlite;

namespace BookLibrary.Other
{
    public static class DBSampleDataOperations
    {
        private const string dbName = "book_library.db";

        public static void FillSampleData()
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
