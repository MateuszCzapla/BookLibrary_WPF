using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;

namespace BookLibrary.ViewModels
{
    public class QueryBookViewModel : BaseViewModel, IDataErrorInfo
    {
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
                OnPropertyChanged("DateTo");
            }
        }

        public QueryBookViewModel()
        {
            title = String.Empty;
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

                switch(columnName)
                {
                    case "Title":
                        if (!string.IsNullOrEmpty(Title) && Title.Length < 2) result = "Title must be a minimum of 2 character";
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
                            //TOTO
                            //this.mediator.Notify(this, "B");
                        },
                        argument => title.Length >= 2 || year != 0 || dateFrom.ToString() != "01.01.0001 00:00:00");
                }
                return searchCommand;
            }
        }
    }
}
