using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Data.Sqlite;

namespace BookLibrary.DataAccessLayer
{
    public static class DBSampleDataOperations
    {
        private const string dbName = "book_library.db";
        private readonly static DateTime unixEpoch = new DateTime(1970, 1, 1);

        public static void FillAuthorSampleData(int sleepTime)
        {
            List<string> insertsList = new List<string>();
            insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Jacek Matulewski', $timeStamp);");
            insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Peter Bell', $timeStamp);");
            insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Brent Beer', $timeStamp);");
            insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Michał Włodarczyk', $timeStamp);");
            insertsList.Add(@"INSERT INTO author(name, timestamp) VALUES('Krzysztof Rychlicki-Kicior', $timeStamp);");

            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                var command = connection.CreateCommand();
                foreach (string insert in insertsList)
                {
                    command.CommandText = insert;
                    command.Parameters.AddWithValue("$timeStamp", DatabaseOperations.DateTimeToUnixTimestamp(DateTime.Now));
                    command.ExecuteNonQuery();
                    Thread.Sleep(sleepTime);
                    command = connection.CreateCommand();
                }
            }
        }
        public static void FillBookSampleData(int sleepTime)
        {
            List<string> insertsList = new List<string>();
            insertsList.Add(@"INSERT INTO book(title, year, timestamp) VALUES('XAML i MVVM w Visual Studio 2015', '2016', $timeStamp);");
            insertsList.Add(@"INSERT INTO book(title, year, timestamp) VALUES('GitHub. Przyjazny przewodnik', '2015', $timeStamp);");
            insertsList.Add(@"INSERT INTO book(title, year, timestamp) VALUES('Git. Rozproszony system kontroli wersji', '2016', $timeStamp);");
            insertsList.Add(@"INSERT INTO book(title, year, timestamp) VALUES('Programowanie obiektowe ITA-105', '2009', $timeStamp);");
            
            for (int i = 0; i <= 100; i++)
            {
                insertsList.Add(@"INSERT INTO book(title, year, timestamp) VALUES('Programowanie obiektowe ITA-105 tom" + i + "', '1" + (i + 1) % 10 + "1" + i % 10 + "', $timeStamp);");
            }

            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                var command = connection.CreateCommand();
                for (int i = 0; i < insertsList.Count; i++)
                {
                    command.CommandText = insertsList[i];
                    command.Parameters.AddWithValue("$timeStamp", DatabaseOperations.DateTimeToUnixTimestamp(DateTime.Now) - 86400 * i - (i * 60 - i));
                    command.ExecuteNonQuery();
                    Thread.Sleep(sleepTime);
                    command = connection.CreateCommand();
                }
            }
        }
        public static void FillAuthorHasBookSampleData()
        {
            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    INSERT INTO author_has_book(author_id, book_id) VALUES('1', '1');
                    INSERT INTO author_has_book(author_id, book_id) VALUES('2', '2');
                    INSERT INTO author_has_book(author_id, book_id) VALUES('3', '2');
                    INSERT INTO author_has_book(author_id, book_id) VALUES('4', '4');
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
