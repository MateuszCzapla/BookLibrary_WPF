//using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class BaseViewModel// : INotifyPropertyChanged
    {
        /*protected Mode mode;

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            this.mode = Mode.Book;
        }*/
    }

    public enum Mode
    {
        Author,
        Book,
        Reader
    }
}
