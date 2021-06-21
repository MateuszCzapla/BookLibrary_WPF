using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        //public ResultViewModel ResultViewModel = null;
        public QueryAuthorViewModel QueryAuthorViewModel = null;
        public QueryBookViewModel QueryBookViewModel = null;
        public QueryReaderViewModel QueryReaderViewModel = null;
        public ModifyAuthorViewModel ModifyAuthorViewModel = null;
        public ModifyBookViewModel ModifyBookViewModel = null;
        public ModifyReaderViewModel ModifyReaderViewModel = null;
        //public BookViewModel BookViewModel = null;

        public ICommand AuthorModeCommand { get; }
        public ICommand BookModeCommand { get; }
        public ICommand ReaderModeCommand { get; }

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

        private object selectedResultViewModel;
        public object SelectedResultViewModel
        {
            get
            {
                return selectedResultViewModel;
            }
            set
            {
                selectedResultViewModel = value;
                OnPropertyChanged("SelectedResultViewModel");
            }
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

        public NavigationViewModel()
        {
            //ResultViewModel = new ResultViewModel();
            QueryAuthorViewModel = new QueryAuthorViewModel();
            QueryBookViewModel = new QueryBookViewModel();
            QueryReaderViewModel = new QueryReaderViewModel();
            ModifyAuthorViewModel = new ModifyAuthorViewModel();
            ModifyBookViewModel = new ModifyBookViewModel();
            ModifyReaderViewModel = new ModifyReaderViewModel();
            //BookViewModel = new BookViewModel();

            AuthorModeCommand = new RelayCommand(SelectAuthorMode);
            BookModeCommand = new RelayCommand(SelectBookMode);
            ReaderModeCommand = new RelayCommand(SelectReaderMode);


            //SelectedViewModel = BookViewModel;
            ModeStatus = Mode.Book;
        }

        private void SelectAuthorMode(object obj)
        {
            //SelectedQueryViewModel = QueryAuthorViewModel;
            //SelectedModifyViewModel = ModifyAuthorViewModel;

            SelectedViewModel = null;
            ModeStatus = Mode.Author;
        }

        private void SelectBookMode(object obj)
        {
            //SelectedViewModel = BookViewModel;
            ModeStatus = Mode.Book;
        }

        private void SelectReaderMode(object obj)
        {
            //SelectedQueryViewModel = QueryReaderViewModel;
            //SelectedModifyViewModel = ModifyReaderViewModel;

            SelectedViewModel = null;
            ModeStatus = Mode.Reader;
        }
    }
}
