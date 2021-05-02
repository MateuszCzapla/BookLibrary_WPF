using System;
using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        //private Mode modeStatus;
        public Mode ModeStatus
        {
            get
            {
                //return base.Mode;
                return Mode.Author;
            }
            set
            {
                base.Mode = value;
                OnPropertyChanged("ModeStatus");
                //RaisePropertyChanged("ModeStatus");
            }
        }

        public StatusViewModel()
        {
            //status = DateTime.Now.ToString();
        }

        /*protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }*/
    }
}
