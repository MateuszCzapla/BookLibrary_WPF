using System.ComponentModel;

namespace BookLibrary.ViewModels
{
    public class QueryViewModel : INotifyPropertyChanged
    {
        private bool editMode;
        public bool EditMode
        {
            get
            {
                return editMode;
            }
            set
            {
                editMode = value;
                OnPropertyChanged("EditMode");
            }
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

        public QueryViewModel()
        {
            this.editMode = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
