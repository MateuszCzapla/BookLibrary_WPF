using System;
using System.Windows.Input;
using System.ComponentModel;

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
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        private DateTime date_from;
        public DateTime Date_from
        {
            get
            {
                return date_from;
            }
            set
            {
                date_from = value;
                OnPropertyChanged("Date_from");
            }
        }

        private DateTime date_to;
        public DateTime Date_to
        {
            get
            {
                return date_to;
            }
            set
            {
                date_to = value;
                OnPropertyChanged("Date_to");
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
                            //TODO
                        },
                        argument => title != String.Empty);
                }
                return searchCommand;
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
                return null;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Title")
                {
                    if (string.IsNullOrEmpty(Title)) return "Title is Required";
                }

                return null;
            }
        }
        #endregion
    }
}
