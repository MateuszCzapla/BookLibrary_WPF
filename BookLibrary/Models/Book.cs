namespace BookLibrary.Models
{
    /// <summary>
    /// The main Book class.
    /// </summary>
    public class Book
    {
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

        public Book(string title, short year)
        {
            this.title = title;
            this.year = year;
        }
    }
}
