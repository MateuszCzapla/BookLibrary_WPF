using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.Generic;

namespace BookLibrary.ViewModels
{
    public class BookViewModel : BaseViewModel, IPageViewModel, IDataErrorInfo
    {
        private List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();

        public string Name
        {
            get
            {
                return "Books";
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                clearEnable = true;
                OnPropertyChanged("ID");
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
                ClearEnable = true;
                OnPropertyChanged("Title");
            }
        }

        private short year;
        public short Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                ClearEnable = true;
                OnPropertyChanged("Year");
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
                ClearEnable = true;
                DateFromChecked = true;
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
                ClearEnable = true;
                DateToChecked = true;
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

        private bool clearEnable;
        public bool ClearEnable
        {
            get
            {
                return clearEnable;
            }
            set
            {
                clearEnable = value;
                OnPropertyChanged("EditMode");
            }
        }

        private bool dateFromChecked;
        public bool DateFromChecked
        {
            get
            {
                return dateFromChecked;
            }
            set
            {
                dateFromChecked = value;
                OnPropertyChanged("DateFromChecked");
            }
        }

        private bool dateToChecked;
        public bool DateToChecked
        {
            get
            {
                return dateToChecked;
            }
            set
            {
                dateToChecked = value;
                OnPropertyChanged("DateToChecked");
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
                            parameters.Add(new Tuple<string, string>("Mode", Mode.Book.ToString()));
                            parameters.Add(new Tuple<string, string>("ID", ID.ToString()));
                            parameters.Add(new Tuple<string, string>("Title", Title));
                            parameters.Add(new Tuple<string, string>("Year", Year.ToString()));
                            if (DateFromChecked) parameters.Add(new Tuple<string, string>("DateFrom", DateFrom.ToString()));
                            if (DateToChecked) parameters.Add(new Tuple<string, string>("DateTo", DateTo.ToString()));
                            
                            resultViewModel.Search(parameters);
                            parameters.Clear();
                        },
                        argument => true);
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
                            ID = 0;
                            Title = string.Empty;
                            Year = 0;
                            DateFrom = DateTime.Today.AddDays(-7.0d);
                            DateTo = DateTime.Today;
                            DateFromChecked = false;
                            DateToChecked = false;
                            ClearEnable = false;
                        },
                        argument => ClearEnable);
                }
                return clearCommand;
            }
        }

        public BookViewModel()
        {
            toolTipTitle = String.Empty;
            resultViewModel = new ResultViewModel();
            dateFrom = DateTime.Today.AddDays(-7.0d);
            dateTo = DateTime.Today;
            dateFromChecked = false;
            dateToChecked = false;
            clearEnable = false;
        }
    }
}
