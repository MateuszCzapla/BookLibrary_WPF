using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        public QueryAuthorViewModel QueryAuthorViewModel = null;
        public QueryBookViewModel QueryBookViewModel = null;
        public QueryReaderViewModel QueryReaderViewModel = null;
        public ModifyAuthorViewModel ModifyAuthorViewModel = null;
        public ModifyBookViewModel ModifyBookViewModel = null;
        public ModifyReaderViewModel ModifyReaderViewModel = null;

        public ICommand AuthorModeCommand { get; set; }
        public ICommand BookModeCommand { get; set; }
        public ICommand ReaderModeCommand { get; set; }

        public NavigationViewModel()
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

            SelectedQueryViewModel = QueryBookViewModel;
            SelectedModifyViewModel = ModifyBookViewModel;
            ModeStatus = Mode.Book;
        }

        private object selectedQueryViewModel;
        public object SelectedQueryViewModel
        {
            get
            {
                return selectedQueryViewModel;
            }
            set
            {
                selectedQueryViewModel = value;
                OnPropertyChanged("SelectedQueryViewModel");
            }
        }

        private object selectedModifyViewModel;
        public object SelectedModifyViewModel
        {
            get
            {
                return selectedModifyViewModel;
            }
            set
            {
                selectedModifyViewModel = value;
                OnPropertyChanged("SelectedModifyViewModel");
            }
        }

        public Mode ModeStatus
        {
            get
            {
                switch (Properties.Settings.Default.Mode)
                {
                    case 0:
                        return Mode.Author;

                    case 1:
                        return Mode.Book;

                    case 2:
                        return Mode.Reader;

                    default:
                        return Mode.Book;
                }
            }
            set
            {
                Properties.Settings.Default.Mode = (byte)value;
                Properties.Settings.Default.Save();

                OnPropertyChanged("ModeStatus");
            }
        }

        private void SelectAuthorMode(object obj)
        {
            SelectedQueryViewModel = new QueryAuthorViewModel();
            SelectedModifyViewModel = new ModifyAuthorViewModel();
            ModeStatus = Mode.Author;
        }

        private void SelectBookMode(object obj)
        {
            SelectedQueryViewModel = new QueryBookViewModel();
            SelectedModifyViewModel = new ModifyBookViewModel();
            ModeStatus = Mode.Book;
        }

        private void SelectReaderMode(object obj)
        {
            SelectedQueryViewModel = new QueryReaderViewModel();
            SelectedModifyViewModel = new ModifyReaderViewModel();
            ModeStatus = Mode.Reader;
        }
    }
}
