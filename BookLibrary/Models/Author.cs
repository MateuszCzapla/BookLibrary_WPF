using System;

namespace BookLibrary.Models
{
    /// <summary>
    /// The main Author class.
    /// </summary>
    public class Author
    {
        private readonly string name;
        public string Name
        {
            get
            {
                return name;
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

        public Author(string name)
        {
            this.name = name;
            this.timestamp = DateTime.Now;
        }
    }
}
