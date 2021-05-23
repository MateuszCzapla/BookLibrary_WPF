using System.Collections.ObjectModel;
using BookLibrary.Models;
using BookLibrary.Other;
using System.Windows.Input;
using System;

namespace BookLibrary.ViewModels
{
    public class OldResultViewModel : BaseViewModel
    {
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
                
                firstRow = 0;
                LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
                PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + totalRowsCount / rowsCount;
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
                            RefreshLibraryGrid();
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
                            RefreshLibraryGrid();
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
                            RefreshLibraryGrid();
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
                            RefreshLibraryGrid();
                        },
                        argument => (firstRow + rowsCount) < totalRowsCount && totalRowsCount > rowsCount);
                }
                return lastPageCommand;
            }
        }

        public OldResultViewModel()
        {
            firstRow = 0;
            rowsCount = 15;
            totalRowsCount = 0;
            RefreshLibraryGrid();
        }

        private void RefreshLibraryGrid()
        {
            LibraryGrid = DatabaseOperations.ReadDatabase(firstRow, rowsCount, ref totalRowsCount);
            PageDisplay = "Page " + (firstRow / rowsCount + 1) + " of " + Math.Ceiling((double)totalRowsCount / rowsCount);
        }
    }
}
