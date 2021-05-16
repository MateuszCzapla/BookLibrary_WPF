using System;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace BookLibrary.ViewModels
{
    public class QueryBookViewModel : BaseViewModel
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

        private byte year;
        public byte Year
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
                        argument => true);
                }
                return searchCommand;
            }
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
