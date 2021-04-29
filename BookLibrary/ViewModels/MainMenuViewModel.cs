using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        //private ICommand lastPageCommand;
        /*public ICommand LastPageCommand
        {
            get
            {
                if (lastPageCommand == null)
                {
                    lastPageCommand = new RelayCommand(
                        argument =>
                        {
                            firstRow = totalRowsCount - rowsCount;
                        },
                        argument => true);
                }
                return lastPageCommand;
            }
        }*/

        public MainMenuViewModel()
        {

        }
    }
}
