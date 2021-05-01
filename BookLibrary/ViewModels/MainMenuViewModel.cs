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
                StatusViewModel statusViewModel = new StatusViewModel();

                if (modeCommand == null)
                {
                    modeCommand = new RelayCommand(
                        argument =>
                        {
                            switch (argument)
                            {
                                case "author":
                                    //Settings.Save(Mode.Author);
                                    statusViewModel.Status = Mode.Author;
                                    break;

                                case "book":
                                    //Settings.Save(Mode.Book);
                                    statusViewModel.Status = Mode.Book;
                                    break;

                                case "reader":
                                    Settings.Save(Mode.Reader);
                                    break;

                                default:
                                    Settings.Save(Mode.Book);
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
