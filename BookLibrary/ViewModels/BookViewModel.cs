using System;
using System.ComponentModel;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class BookViewModel : BaseViewModel, IPageViewModel
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

        private DateTime dateFrom;
        public DateTime DateFrom
        {
            get
            {
                return dateFrom;
            }
            set
            {
                dateFrom = value;
                //DateToEnable = true;
                OnPropertyChanged("DateToEnable");
                OnPropertyChanged("DateFrom");
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
                            resultViewModel.TestResultVM();
                        },
                        argument => true);
                }
                return searchCommand;
            }
        }

        public BookViewModel()
        {
            //this.editMode = false;
            //this.searchText = "binding test";
            this.resultViewModel = new ResultViewModel();
        }
    }
}
