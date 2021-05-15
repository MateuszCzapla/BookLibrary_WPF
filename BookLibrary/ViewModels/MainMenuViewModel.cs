using System.Windows.Input;


namespace BookLibrary.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public QueryAuthorViewModel QueryAuthorViewModel = null;
        public QueryBookViewModel QueryBookViewModel = null;
        public ModifyAuthorViewModel ModifyAuthorViewModel = null;
        public ModifyBookViewModel ModifyBookViewModel = null;

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

                                    //DataContext = QueryAuthorViewModel;

                                    //MainWindow.DataContext = QueryAuthorViewModel;
                                    //MainWindow.DataContext = ModifyAuthorViewModel;
                                    break;

                                case "book":
                                    //base.Mode = Mode.Book;
                                    //Test = "Z menu 1";

                                    //this.Test2 = "Z menu book";//OK
                                    TestBase = "Z base book";

                                    //SetProperty(ref base.mode, Mode.Book);
                                    //base.Test = "Book";
                                    //OnPropertyChanged();

                                    //MainWindow.DataContext = QueryBookViewModel;
                                    //MainWindow.DataContext = ModifyBookViewModel;
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
            QueryAuthorViewModel = new QueryAuthorViewModel();
            QueryBookViewModel = new QueryBookViewModel();
            ModifyAuthorViewModel = new ModifyAuthorViewModel();
            ModifyBookViewModel = new ModifyBookViewModel();

            //MainWindow = new MainWindow();

            EmpCommand = new RelayCommand(OpenEmp);
            DeptCommand = new RelayCommand(OpenDept);
        }

        ////
        ///
        public ICommand EmpCommand { get; set; }
        public ICommand DeptCommand { get; set; }

        private object selectedViewModel;
        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }


        private void OpenEmp(object obj)
        {
            //SelectedViewModel = new EmployeeViewModel();
            SelectedViewModel = new QueryAuthorViewModel();
        }

        private void OpenDept(object obj)
        {
            //SelectedViewModel = new DepartmentViewModel();
            SelectedViewModel = new QueryBookViewModel();
        }
    }
}
