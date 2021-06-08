using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class BaseViewModel : DependencyObject, INotifyPropertyChanged
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
    }

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
