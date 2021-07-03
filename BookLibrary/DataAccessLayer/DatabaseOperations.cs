using System;
using System.IO;
using Microsoft.Data.Sqlite;
using BookLibrary.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace BookLibrary.DataAccessLayer
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
                    CREATE TABLE authors (id INTEGER PRIMARY KEY, name TEXT, timestamp INTEGER);
                    CREATE TABLE books (id INTEGER PRIMARY KEY, title TEXT, year INTEGER, timestamp INTEGER);
                    CREATE TABLE author_has_book (author_id INTEGER, book_id INTEGER);
                ";
                command.ExecuteNonQuery();
            }

            DBSampleDataOperations.FillAuthorSampleData(1000);
            DBSampleDataOperations.FillBookSampleData(1);
            DBSampleDataOperations.FillAuthorHasBookSampleData();
        }

        public static ObservableCollection<Book> ReadDataBase(List<Tuple<string, string>> parameters, int firstRow, int rowsCount, ref int totalRowsCount)
        {
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            if (!File.Exists(dbName)) return books;

            using (SqliteConnection connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                List<Tuple<string, string>> valueParameters = new List<Tuple<string, string>>();
                valueParameters = PrepareSqlQuery(parameters);
                command.CommandText = valueParameters[valueParameters.Count - 1].Item2;

                for (int i = 1; i < valueParameters.Count - 1; i++)
                {
                    command.Parameters.AddWithValue("$" + valueParameters[i].Item1, valueParameters[i].Item2);
                }

                command.Parameters.AddWithValue("$firstRow", firstRow);
                command.Parameters.AddWithValue("$rowsCount", rowsCount);

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetInt16(2),
                            UnixTimestampToDateTime(reader.GetInt32(3))
                        ));
                    }
                }

                totalRowsCount = ReadAllRows(valueParameters);
                if (parameters != null) parameters.Clear();
            }
            return books;
        }

        private static List<Tuple<string, string>> PrepareSqlQuery(List<Tuple<string, string>> parameters)
        {
            string selectSyntax = "FROM books";
            if (parameters == null)
            {
                parameters = new List<Tuple<string, string>>();
                parameters.Add(new Tuple<string, string>("Query1", "SELECT COUNT(*) " + selectSyntax));
                selectSyntax += " LIMIT $firstRow, $rowsCount";
                parameters.Add(new Tuple<string, string>("Query2", "SELECT id, title, year, timestamp " + selectSyntax));
                return parameters;
            }

            List<int> removeIndexList = new List<int>();
            for (int i = 1; i < parameters.Count; i++)
            {
                if (parameters[i].Item2 == "0" || parameters[i].Item2 == "01.01.0001 00:00:00" || parameters[i].Item2 == string.Empty || parameters[i].Item2 == null)
                { 
                    removeIndexList.Add(i);
                }
            }
            for (int i = removeIndexList.Count - 1; i >= 0; i--) parameters.RemoveAt(removeIndexList[i]);
            if (parameters.Count < 2)
            {
                parameters.Add(new Tuple<string, string>("Query1", "SELECT COUNT(*) " + selectSyntax));
                selectSyntax += " LIMIT $firstRow, $rowsCount";
                parameters.Add(new Tuple<string, string>("Query2", "SELECT id, title, year, timestamp " + selectSyntax));
                return parameters;
            }

            bool andFlag = false;
            selectSyntax += " WHERE";
            if (parameters[0].Item2 == "Author") throw new NotImplementedException();
            if (parameters[0].Item2 == "Book")
            {
                for (int i = 0; i < parameters.Count; i++)
                {
                    switch (parameters[i].Item1)
                    {
                        case "ID":
                            if (andFlag) selectSyntax += " AND";
                            selectSyntax += " id = $id";
                            parameters[i] = new Tuple<string, string>("id", parameters[i].Item2);
                            andFlag = true;
                            break;

                        case "Title":
                            if (andFlag) selectSyntax += " AND";
                            selectSyntax += " title LIKE $title";
                            parameters[i] = new Tuple<string, string>("title", "%" + parameters[i].Item2 + "%");
                            andFlag = true;
                            break;

                        case "Year":
                            if (andFlag) selectSyntax += " AND";
                            selectSyntax += " year = $year";
                            parameters[i] = new Tuple<string, string>("year", parameters[i].Item2);
                            andFlag = true;
                            break;

                        case "DateFrom":
                            if (andFlag) selectSyntax += " AND";
                            selectSyntax += " timestamp > $dateFrom";
                            parameters[i] = new Tuple<string, string>("dateFrom", DateTimeToUnixTimestamp(DateTime.Parse(parameters[i].Item2)).ToString());
                            andFlag = true;
                            break;

                        case "DateTo":
                            if (andFlag) selectSyntax += " AND";
                            selectSyntax += " timestamp < $dateTo";
                            parameters[i] = new Tuple<string, string>("dateTo", DateTimeToUnixTimestamp(DateTime.Parse(parameters[i].Item2)).ToString());
                            andFlag = true;
                            break;
                    }
                }
            }
            if (parameters[0].Item2 == "Reader") throw new NotImplementedException();

            parameters.Add(new Tuple<string, string>("Query1", "SELECT COUNT(*) " + selectSyntax));
            parameters.Add(new Tuple<string, string>("Query2", "SELECT id, title, year, timestamp " + selectSyntax + " LIMIT $firstRow, $rowsCount"));
            return parameters;
        }

        private static int ReadAllRows(List<Tuple<string, string>> valueParameters)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=" + dbName))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                if (valueParameters == null) command.CommandText = @"SELECT COUNT(*) FROM books;";

                command.CommandText = valueParameters[valueParameters.Count - 2].Item2;
                for (int i = 1; i < valueParameters.Count - 2; i++)
                {
                    command.Parameters.AddWithValue("$" + valueParameters[i].Item1, valueParameters[i].Item2);
                }
                if (valueParameters != null) valueParameters.Clear();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    return reader.GetInt32(0);
                }
            }
        }

        public static DateTime UnixTimestampToDateTime(int unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTime date = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            return date;
        }

        public static long DateTimeToUnixTimestamp(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }
    }
}
