using System.ComponentModel;
using System.Collections.ObjectModel;
using BookLibrary.Models;
using BookLibrary.Other;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class LibraryGridViewModel : INotifyPropertyChanged
    {
        private bool editMode = false;
        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                editMode = value;
                OnPropertyChanged("EditMode");
            }
        }

        private int totalRowsCount;
        public string TotalRowsCount
        {
            get
            {
                return totalRowsCount.ToString();
            }
            set
            {
                totalRowsCount = int.Parse(value);
            }
        }

        private ObservableCollection<Book> libraryGrid;
        public ObservableCollection<Book> LibraryGrid
        {
            get { return libraryGrid; }
            set { libraryGrid = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand selectCommand;
        public ICommand Select
        {
            get
            {
                if (selectCommand == null) selectCommand = new SelectCommand();
                return selectCommand;
            }
        }

        public LibraryGridViewModel()
        {
            this.totalRowsCount = 10;
            libraryGrid = DatabaseOperations.ReadDatabase(this.totalRowsCount, ref this.totalRowsCount);
        }

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
