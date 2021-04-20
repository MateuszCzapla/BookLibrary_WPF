namespace BookLibrary.Models
{
    /// <summary>
    /// The main Author class.
    /// </summary>
    public class Author
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }

        public Author(string name)
        {
            this.name = name;
        }
    }
}
