using System.ComponentModel;

namespace BookLibrary.ViewModels
{ 
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public BaseViewModel()
        {
            
        }
    }

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
