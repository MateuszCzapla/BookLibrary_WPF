using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookLibrary.ViewModels
{ 
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string testBase;
        public string TestBase
        {
            get
            {
                return testBase;
            }
            set
            {
                testBase = value;
                //OnPropertyChanged("Test");
                //OnPropertyChanged();

                OnPropertyChanged("TestBase");
                //RaisePropertyChanged("TestBase");

                SetProperty(ref testBase, value);
            }
        }

        protected Mode mode;
        public Mode Mode
        {
            get
            {
                switch (Properties.Settings.Default.Mode)
                {
                    case 0:
                        return Mode.Author;

                    case 1:
                        return Mode.Book;

                    case 2:
                        return Mode.Reader;

                    default:
                        return Mode.Book;
                }
            }
            set
            {
                mode = value;

                Properties.Settings.Default.Mode = (byte)value;
                Properties.Settings.Default.Save();
                //RaisePropertyChanged("Mode");
                //OnPropertyChanged("Mode");
                //OnPropertyChanged();
                //OnPropertyChanged();
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        /*protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        /*protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        /*protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }*/

        protected void OnPropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    //PropertyChanged();
                }
            }
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        public BaseViewModel()
        {
            Properties.Settings.Default.Mode = 0;
            this.testBase = "Testowy tekst base.";
        }
    }

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
