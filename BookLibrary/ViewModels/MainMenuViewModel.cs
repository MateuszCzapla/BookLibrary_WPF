using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        private string test2;
        public string Test2
        {
            get
            {
                return test2;
            }
            set
            {
                test2 = value;
                OnPropertyChanged("Test2");
            }
        }

        private ICommand modeCommand;
        public ICommand ModeCommand
        {
            get
            {
                StatusViewModel statusViewModel = new StatusViewModel();

                if (modeCommand == null)
                {
                    modeCommand = new RelayCommand(
                        argument =>
                        {
                            switch (argument)
                            {
                                case "author":
                                    base.Mode = Mode.Author;
                                    break;

                                case "book":
                                    base.Mode = Mode.Book;
                                    Test = "Z menu 1";
                                    break;

                                case "reader":
                                    base.Mode = Mode.Reader;

                                    Test = "Z menu 2";
                                    break;

                                default:
                                    base.Mode = Mode.Book;
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
