using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public string Testt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            //this.mode = Mode.Book;
        }

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
