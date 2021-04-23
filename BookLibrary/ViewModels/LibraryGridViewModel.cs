using System.ComponentModel;
using System.Collections.ObjectModel;
using BookLibrary.Models;
using BookLibrary.Other;

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

        private ObservableCollection<Book> libraryGrid;
        public ObservableCollection<Book> LibraryGrid
        {
            get { return libraryGrid; }
            set { libraryGrid = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LibraryGridViewModel()
        {
            //libraryGrid = new ObservableCollection<Book>();
            //libraryGrid.Add(new Book("rrr", 3333));
            //libraryGrid.Add(new Book("www", 4444));

            libraryGrid = DatabaseOperations.ReadDatabase();
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
