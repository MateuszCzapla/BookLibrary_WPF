using System;
using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        public Mode Status
        {
            get
            {
                return Settings.Read();
            }
            set
            {
                Settings.Save(value);
                OnPropertyChanged("Status");
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
