using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace BookLibrary.ViewModels
{
    public class BookViewModel : BaseViewModel, IPageViewModel, IDataErrorInfo
    {
        public string Name
        {
            get
            {
                return "Books";
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                searchAble = true;
                OnPropertyChanged("Title");
            }
        }

        private short year;
        public short Year
        {
            get
            {
                //return year.ToString();
                return year;
            }
            set
            {
                //year = Convert.ToInt16(value);
                year = value;
                searchAble = true;
                OnPropertyChanged("Year");
            }
        }

        public bool DateToEnable { get; set; } = false;

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
                DateToEnable = true;
                searchAble = true;
                OnPropertyChanged("DateToEnable");
                OnPropertyChanged("DateFrom");
            }
        }

        private DateTime dateTo;
        public DateTime DateTo
        {
            get
            {
                return dateTo;
            }
            set
            {
                dateTo = value;
                searchAble = true;
                OnPropertyChanged("DateTo");
            }
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

        private bool searchAble;
        public bool SearchAble
        {
            get
            {
                return searchAble;
            }
            set
            {
                searchAble = value;
                OnPropertyChanged("EditMode");
            }
        }

        private bool expanderIsExpanded;
        public bool ExpanderIsExpanded
        {
            get
            {
                return expanderIsExpanded;
            }
            set
            {
                expanderIsExpanded = value;
                OnPropertyChanged("ExpanderIsExpanded");
            }
        }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Title":
                        if (!string.IsNullOrEmpty(Title) && Title.Length < 2)
                        {
                            result = "Title must be a minimum of 2 character";
                        }
                        break;

                    case "Year":
                        if (!string.IsNullOrEmpty(Title) && Title.Length < 2) result = "Title must be a minimum of 2 character";
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName)) ErrorCollection[columnName] = result;
                else if (result != null) ErrorCollection.Add(columnName, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        private string toolTipTitle;
        public string ToolTipTitle
        {
            get
            {
                return "test";
            }
        }

        #endregion

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
                            //resultViewModel.TestResultVM();
                            resultViewModel.Search(Title);
                        },
                        argument => SearchAble);
                }
                return searchCommand;
            }
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(
                        argument =>
                        {
                            Title = String.Empty;
                            Year = 0;
                            DateFrom = DateTime.MinValue;
                            DateTo = DateTime.MinValue;
                            searchAble = false;
                            ExpanderIsExpanded = false;
                            DateToEnable = false;
                        },
                        argument => searchAble);
                }
                return clearCommand;
            }
        }

        public BookViewModel()
        {
            searchAble = false;
            toolTipTitle = String.Empty;
            resultViewModel = new ResultViewModel();
            ExpanderIsExpanded = false;
        }
    }
}
