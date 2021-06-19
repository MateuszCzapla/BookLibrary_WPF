using System.ComponentModel;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class BookViewModel : INotifyPropertyChanged, IPageViewModel
    {
        public string Name
        {
            get { return "Books"; }
        }

        private ResultViewModel resultViewModel;
        public ResultViewModel ResultViewModell
        {
            get
            {
                return resultViewModel;
            }
            set
            {
                resultViewModel = value;
                OnPropertyChanged("ResultViewModell");
            }
        }

        private bool editMode;
        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                editMode = value;
                OnPropertyChanged("EditMode");
            }
        }

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        private ICommand searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                {
                    searchCommand = new RelayCommand(
                        argument =>
                        {
                            //firstRow = totalRowsCount - rowsCount;
                            resultViewModel.TestResultVM();
                        },
                        argument => true);
                }
                return searchCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BookViewModel()
        {
            this.editMode = false;
            this.searchText = "binding test";
            this.resultViewModel = new ResultViewModel();
        }
    }
}
