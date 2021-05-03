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
                //StatusViewModel statusViewModel = new StatusViewModel();

                if (modeCommand == null)
                {
                    modeCommand = new RelayCommand(
                        argument =>
                        {
                            switch (argument)
                            {
                                case "author":
                                    //base.Mode = Mode.Author;
                                    //SetProperty(ref base.mode, Mode.Author);
                                    //SetProperty("Mode");
                                    //base.Test = "Autor";

                                    //this.Test2 = "Z menu author";//OK
                                    TestBase = "Z base author";

                                    //OnPropertyChanged();
                                    break;

                                case "book":
                                    //base.Mode = Mode.Book;
                                    //Test = "Z menu 1";

                                    //this.Test2 = "Z menu book";//OK
                                    TestBase = "Z base book";

                                    //SetProperty(ref base.mode, Mode.Book);
                                    //base.Test = "Book";
                                    //OnPropertyChanged();
                                    break;

                                case "reader":
                                    //base.Mode = Mode.Reader;
                                    //Test = "Z menu 2";

                                    //this.Test2 = "Z menu reader";//OK
                                    TestBase = "Z base reader";

                                    //SetProperty(ref base.mode, Mode.Reader);
                                    //base.Test = "Reader";
                                    //OnPropertyChanged();
                                    break;

                                default:
                                    //base.Mode = Mode.Book;
                                    //SetProperty(ref base.mode, Mode.Book);
                                    //base.Test = "Book";

                                    //this.Test2 = "Z menu book";//OK
                                    TestBase = "Z base book";

                                    //OnPropertyChanged();
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
