using System;

namespace BookLibrary.Models
{
    /// <summary>
    /// The main Book class.
    /// </summary>
    public class Book
    {
        private int nr;
        public int Nr
        {
            get
            {
                return nr;
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

        public Book(int nr, string title, short year)
        {
            this.nr = nr;
            this.title = title;
            this.year = year;
            this.timestamp = DateTime.Now;
        }
    }
}
