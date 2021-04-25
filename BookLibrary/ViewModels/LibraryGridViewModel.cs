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

        private int firstRow;
        public int FirstRow
        {
            get
            {
                return firstRow;
            }
            set
            {
                firstRow = value;
                OnPropertyChanged("FirstRow");
            }
        }

        private int rowsCount;
        public int RowsCount
        {
            get
            {
                return rowsCount;
            }
            set
            {
                rowsCount = value;
                OnPropertyChanged("RowsCount");
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
                OnPropertyChanged("TotalRowsCount");
            }
        }

        private string pageDisplay;
        public string PageDisplay
        {
            get
            {
                return pageDisplay;
            }
            set
            {
                pageDisplay = value;
                OnPropertyChanged("PageDisplay");
            }
        }

        private ObservableCollection<Book> libraryGrid;
        public ObservableCollection<Book> LibraryGrid
        {
            get { return libraryGrid; }
            set
            {
                libraryGrid = value;
                OnPropertyChanged("LibraryGrid");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand nextPageCommand;
        public ICommand NextPageCommand
        {
            get
            {
                if (nextPageCommand == null)
                {
                    nextPageCommand = new RelayCommand(
                        argument =>
                        {
                            firstRow += rowsCount;
                            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
                            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
                        },
                        argument => (firstRow + rowsCount) < totalRowsCount);
                }
                return nextPageCommand;
            }
        }

        private ICommand previousPageCommand;
        public ICommand PreviousPageCommand
        {
            get
            {
                if (previousPageCommand == null)
                {
                    previousPageCommand = new RelayCommand(
                        argument =>
                        {
                            firstRow -= rowsCount;
                            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
                            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
                        },
                        argument => firstRow >= rowsCount);
                }
                return previousPageCommand;
            }
        }

        private ICommand firstPageCommand;
        public ICommand FirstPageCommand
        {
            get
            {
                if (firstPageCommand == null)
                {
                    firstPageCommand = new RelayCommand(
                        argument =>
                        {
                            firstRow = 0;
                            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
                            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
                        },
                        argument => firstRow >= rowsCount);
                }
                return firstPageCommand;
            }
        }

        private ICommand lastPageCommand;
        public ICommand LastPageCommand
        {
            get
            {
                if (lastPageCommand == null)
                {
                    lastPageCommand = new RelayCommand(
                        argument =>
                        {
                            firstRow = totalRowsCount - rowsCount;
                            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
                            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
                        },
                        argument => (firstRow + rowsCount) < totalRowsCount && totalRowsCount > rowsCount);
                }
                return lastPageCommand;
            }
        }

        public LibraryGridViewModel()
        {
            firstRow = 0;
            rowsCount = 5;
            totalRowsCount = 0;
            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
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
