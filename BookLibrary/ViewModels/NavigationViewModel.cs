using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        public ICommand EmpCommand { get; set; }
        public ICommand DeptCommand { get; set; }
        private object selectedViewModel;
        public object SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }
        public NavigationViewModel()
        {
            EmpCommand = new RelayCommand(OpenEmp);
            DeptCommand = new RelayCommand(OpenDept);
        }
        private void OpenEmp(object obj)
        {
            SelectedViewModel = new QueryAuthorViewModel();
        }
        private void OpenDept(object obj)
        {
            SelectedViewModel = new QueryBookViewModel();
        }
    }
}
