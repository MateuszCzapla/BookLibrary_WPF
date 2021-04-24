using System;
using System.Windows.Input;
using BookLibrary.Other;
using BookLibrary.ViewModels;

namespace BookLibrary.ViewModels
{
    public class SelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            LibraryGridViewModel libraryGridViewModel = parameter as LibraryGridViewModel;
            if (libraryGridViewModel != null)
            {
                //libraryGridViewModel.
                //libraryGrid = DatabaseOperations.ReadDatabase(this.totalRowsCount, ref this.totalRowsCount);
                //libraryGridViewModel.LibraryGrid = DatabaseOperations.ReadDatabase(libraryGridViewModel.TotalRowsCount, ref this.totalRowsCount);
            }
        }
    }
}
