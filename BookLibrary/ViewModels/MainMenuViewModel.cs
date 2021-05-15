using System.Windows.Input;


namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public QueryAuthorViewModel QueryAuthorViewModel = null;
        public QueryBookViewModel QueryBookViewModel = null;
        public QueryReaderViewModel QueryReaderViewModel = null;
        public ModifyAuthorViewModel ModifyAuthorViewModel = null;
        public ModifyBookViewModel ModifyBookViewModel = null;
        public ModifyReaderViewModel ModifyReaderViewModel = null;

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
                                    TestBase = "Z base author";
                                    break;

                                case "book":
                                    TestBase = "Z base book";
                                    break;

                                case "reader":
                                    TestBase = "Z base reader";
                                    break;

                                default:
                                    TestBase = "Z base book";
                                    break;
                            }
                        },
                        argument => true);
                }
                return modeCommand;
            }
        }

        public ICommand AuthorModeCommand { get; set; }
        public ICommand BookModeCommand { get; set; }
        public ICommand ReaderModeCommand { get; set; }

        public MainMenuViewModel()
        {
            QueryAuthorViewModel = new QueryAuthorViewModel();
            QueryBookViewModel = new QueryBookViewModel();
            QueryReaderViewModel = new QueryReaderViewModel();
            ModifyAuthorViewModel = new ModifyAuthorViewModel();
            ModifyBookViewModel = new ModifyBookViewModel();
            ModifyReaderViewModel = new ModifyReaderViewModel();

            AuthorModeCommand = new RelayCommand(SelectAuthorMode);
            BookModeCommand = new RelayCommand(SelectBookMode);
            ReaderModeCommand = new RelayCommand(SelectReaderMode);
        }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }


        private void SelectAuthorMode(object obj)
        {
            SelectedViewModel = new QueryAuthorViewModel();
        }

        private void SelectBookMode(object obj)
        {
            SelectedViewModel = new QueryBookViewModel();
        }

        private void SelectReaderMode(object obj)
        {
            SelectedViewModel = new QueryReaderViewModel();
        }
    }
}
