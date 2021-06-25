using System;
using System.Reflection;
using System.IO;
using Microsoft.Data.Sqlite;
using BookLibrary.Models;
using System.Collections.ObjectModel;
using BookLibrary.ViewModels.Books;

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
            DBSampleDataOperations.FillBookSampleData(1);
            DBSampleDataOperations.FillAuthorHasBookSampleData();
        }

        public static ObservableCollection<Book> ReadDataBase(int firstRow, int rowsCount, ref int totalRowsCount)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            if (!File.Exists(dbName)) return books;

            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =@"SELECT COUNT(*) FROM book;";
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    totalRowsCount = reader.GetInt32(0);
                }

                command.CommandText =
                @"
                    SELECT id, title, year, timestamp
                    FROM book LIMIT $firstRow, $rowsCount
                ";
                command.Parameters.AddWithValue("$firstRow", firstRow);
                command.Parameters.AddWithValue("$rowsCount", rowsCount);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0), reader.GetString(1), 1111));
                    }
                }
            }

            return books;
        }

        public static ObservableCollection<Book> ReadDataBase(int id, string title, int year, string dateFrom, string dateTo)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            if (!File.Exists(dbName)) return books;

            using (var connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText =
                @"
                    SELECT id, title, year, timestamp
                    FROM book WHERE title LIKE $title
                ";
                command.Parameters.AddWithValue("$title", "%" + title + "%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0), reader.GetString(1), 1111));
                    }
                }
            }

            return books;
        }

        public static ObservableCollection<Book> ReadDataBase(string[] parameters, int firstRow, int rowsCount, ref int totalRowsCount)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            if (!File.Exists(dbName)) return books;
            //if (bookParameters == null) return books;

            using (SqliteConnection connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                totalRowsCount = readAllRows(connection);

                SqliteCommand command = connection.CreateCommand();
                createSelectSyntax(parameters, command, firstRow, rowsCount);

                command.CommandText = "SELECT id, title, year, timestamp FROM book LIMIT $firstRow, $rowsCount";
                command.Parameters.AddWithValue("$firstRow", firstRow);
                command.Parameters.AddWithValue("$rowsCount", rowsCount);
                //command.Parameters.AddWithValue("$title", "%" + bookParameters.Title + "%");*/

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(reader.GetInt32(0), reader.GetString(1), 1111));
                    }
                }
            }

            return books;
        }

        private static int readAllRows(SqliteConnection connection)
        {
            if (connection == null) return -1;

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT COUNT(*) FROM book;";
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                return reader.GetInt32(0);
            }
        }

        private static string createSelectSyntax(string[] parameters, SqliteCommand command, int firstRow, int rowsCount)
        {
            string selectSyntax = "SELECT id, title, year, timestamp FROM book";
            if (parameters == null) return selectSyntax;
            bool whereFlag = false;
            bool andFlag = false;

            if (parameters[0] == "Book")
            {
                for (int i = 1; i < parameters.Length; i++)
                {
                    if (parameters[i] == string.Empty) continue;
                    if (!whereFlag) selectSyntax += " WHERE";
                    whereFlag = true;
                    if (andFlag) selectSyntax += " AND";

                    switch (i)
                    {
                        
                        case 1://ID
                            selectSyntax += " id = $id";
                            andFlag = true;
                            break;
                        case 2://Title
                            selectSyntax += " title LIKE $title";
                            andFlag = true;
                            break;
                        case 3://Year
                            selectSyntax += " year = $year";
                            break;
                        case 4://DateFrom
                            //Console.WriteLine("Case 2");
                            break;
                        case 5://DateTo
                            //Console.WriteLine("Case 2");
                            break;
                        default:
                            //Console.WriteLine("Default case");
                            break;
                    }
                }
            }

            return selectSyntax;
        }

        private static string[] defaultValuesToStringEmpty(string[] parameters)
        {
            for (int i = 1; i < parameters.Length; i++)
            {
                if (parameters[i] == "0" || parameters[i] == "01.01.0001 00:00:00")
                {
                    parameters[i] = string.Empty;
                }
            }

            return parameters;
        }
    }
}
