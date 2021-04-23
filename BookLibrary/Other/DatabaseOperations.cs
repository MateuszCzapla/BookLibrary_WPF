using System.IO;
using Microsoft.Data.Sqlite;
using BookLibrary.Models;
using System.Collections.ObjectModel;

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
                    CREATE TABLE book (id INTEGER PRIMARY KEY, title TEXT, year INTEGER, timestamp INTEGER);
                    CREATE TABLE author_has_book (author_id INTEGER, book_id INTEGER);
                ";
                command.ExecuteNonQuery();
            }

            DBSampleDataOperations.FillAuthorSampleData(1000);
            DBSampleDataOperations.FillBookSampleData(1000);
            DBSampleDataOperations.FillAuthorHasBookSampleData();
        }

        public static ObservableCollection<Book> ReadDatabase()
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();

                var command = connection.CreateCommand();
                /*command.CommandText =
                @"
                    SELECT name
                    FROM user
                    WHERE id = $id
                ";
                command.Parameters.AddWithValue("$id", id);*/

                command.CommandText =
                @"
                    SELECT id, title, year, timestamp
                    FROM book
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetString(1), 1111));
                    }
                }
            }

            return books;
        }
    }
}
