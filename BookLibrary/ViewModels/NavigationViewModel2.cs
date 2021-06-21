using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace BookLibrary.ViewModels
{
    public class NavigationViewModel2 : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        //private IPageViewModel _currentPageViewModel_2;
        //private ObservableCollection<IPageViewModel> _pageViewModels_2;

        #endregion

        public NavigationViewModel2()
        {
            PageViewModels.Add(new BookViewModel());
            PageViewModels.Add(new ProductsViewModel());
            CurrentPageViewModel = PageViewModels[0];

            //PageViewModels_2.Add(new BookViewModel());
            //PageViewModels_2.Add(new ProductsViewModel());
            //CurrentPageViewModel = PageViewModels_2[0];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IPageViewModel)p),
                        p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null) _pageViewModels = new List<IPageViewModel>();
                return _pageViewModels;
            }
        }

        /*public ObservableCollection<IPageViewModel> PageViewModels_2
        {
            get
            {
                //if (_pageViewModels == null) _pageViewModels = new List<IPageViewModel>();
                //return _pageViewModels;

                if (_pageViewModels == null) _pageViewModels_2 = new ObservableCollection<IPageViewModel>();
                return _pageViewModels_2;
            }
        }*/

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        #endregion

        #region Methods

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel)) PageViewModels.Add(viewModel);
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        #endregion
    }
}
