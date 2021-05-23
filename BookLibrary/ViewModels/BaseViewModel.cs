using System.ComponentModel;
using BookLibrary.ViewModels.Mediator;

namespace BookLibrary.ViewModels
{ 
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IMediator mediator;
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel(IMediator mediator = null)
        {
            this.mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
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

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
