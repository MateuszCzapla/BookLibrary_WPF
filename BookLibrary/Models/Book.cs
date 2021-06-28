using System;

namespace BookLibrary.Models
{
    /// <summary>
    /// The Book class.
    /// </summary>
    public class Book
    {
        private int id;
        public int ID
        {
            get
            {
                return id;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
        }

        private short year;
        public short Year
        {
            get
            {
                return year;
            }
        }
        private readonly DateTime timestamp;
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
        }

        public Book(int id, string title, short year) : this(id, title, year, DateTime.Now)
        {
        }

        public Book(int id, string title, short year, DateTime timestamp)
        {
            this.id = id;
            this.title = title;
            this.year = year;
            this.timestamp = timestamp;
        }
    }
}
