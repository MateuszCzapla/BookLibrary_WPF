using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public abstract class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] nazwyWłasności)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWłasności in nazwyWłasności)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
                }
            }
        }
    }
}
