﻿using System;
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
                            resultViewModel.TestResultVM();
                        },
                        argument => true);
                }
                return searchCommand;
            }
        }

        public BookViewModel()
        {
            title = String.Empty;
            this.toolTipTitle = String.Empty;

            //this.editMode = false;
            //this.searchText = "binding test";
            this.resultViewModel = new ResultViewModel();
        }
    }
}
