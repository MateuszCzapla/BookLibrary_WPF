namespace BookLibrary.ViewModels.Books
{
    public class BookParameters
    {
        private int id;
        private string title;
        private short year;
        private string dateFrom;
        private string dateTo;

        public int ID
        {
            get { return id; }
        }

        public string Title
        {
            get { return title; }
        }

        public short Year
        {
            get { return year; }
        }

        public string DateFrom
        {
            get { return dateFrom; }
        }

        public string DateTo
        {
            get { return dateTo; }
        }

        public BookParameters(int id, string title, short year, string dateFrom, string dateTo)
        {
            this.id = id;
            this.title = title;
            this.year = year;
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
        }
    }
}
