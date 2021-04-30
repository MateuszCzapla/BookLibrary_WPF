using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected Mode mode;
        /*public Mode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                value = mode;
                OnPropertyChanged("Mode");
            }
        }*/
  

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            this.mode = Mode.Book;
        }
    }

    public enum Mode
    {
        Author,
        Book,
        Reader
    }
}
