using System.Windows;
using System.ComponentModel;
using BookLibrary.ViewModels.Mediator;
using System.Windows.Controls;
using System.Windows.Input;
//using System.Windows;

namespace BookLibrary.ViewModels
{
    //public class BaseViewModel : Behavior<Window>, INotifyPropertyChanged
    public class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        protected IMediator mediator;
        public event PropertyChangedEventHandler PropertyChanged;

        //public BaseViewModel(IMediator mediator)
        public BaseViewModel(IMediator mediator = null)
        {
            if (this.mediator == null) this.mediator = mediator;
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
