using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BookLibrary.ViewModels
{ 
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string test;
        public string Test
        {
            get
            {
                return test;
            }
            set
            {
                test = value;
               // OnPropertyChanged("Test");
                OnPropertyChanged();
            }
        }

        private Mode mode;
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
                OnPropertyChanged();
            }
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public BaseViewModel()
        {
            Properties.Settings.Default.Mode = 0;
            this.test = "Testowy tekst.";
        }
    }

    public enum Mode : byte
    {
        Author = 0,
        Book = 1,
        Reader = 2
    }
}
