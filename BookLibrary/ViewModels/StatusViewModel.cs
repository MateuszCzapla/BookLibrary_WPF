using System;
using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        private string status;
        public string Status
        {
            get
            {
                return status;
                //return base.mode.ToString();
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
