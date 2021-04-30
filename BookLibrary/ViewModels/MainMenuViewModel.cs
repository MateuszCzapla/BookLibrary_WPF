using System.Windows.Input;
using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
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
                            //firstRow = totalRowsCount - rowsCount;
                        },
                        argument => true);
                }
                return lastPageCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainMenuViewModel()
        {

        }
    }
}
