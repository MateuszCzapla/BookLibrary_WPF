using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //EmpCommand = new BaseCommand(OpenEmp);
            EmpCommand = new RelayCommand(OpenEmp);
            //DeptCommand = new BaseCommand(OpenDept);
            DeptCommand = new RelayCommand(OpenDept);
        }
        private void OpenEmp(object obj)
        {
            //SelectedViewModel = new EmployeeViewModel();
            SelectedViewModel = new QueryAuthorViewModel();
        }
        private void OpenDept(object obj)
        {
            //SelectedViewModel = new DepartmentViewModel();
            SelectedViewModel = new QueryBookViewModel();
        }
    }
}
