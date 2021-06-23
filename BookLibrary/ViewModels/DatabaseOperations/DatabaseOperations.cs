﻿using System;
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
    }
}
