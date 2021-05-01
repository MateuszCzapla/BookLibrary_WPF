using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private ICommand modeCommand;
        public ICommand ModeCommand
        {
            get
            {
                if (modeCommand == null)
                {
                    modeCommand = new RelayCommand(
                        argument =>
                        {
                            switch (argument)
                            {
                                case "author":
                                    //base.mode = Mode.Author;
                                    break;
                                case "book":
                                    //base.mode = Mode.Book;
                                    break;
                                case "reader":
                                    //base.mode = Mode.Reader;
                                    break;
                            }
                        },
                        argument => true);
                }
                return modeCommand;
            }
        }

        public MainMenuViewModel()
        {

        }
    }
}
