using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace BookLibrary.ViewModels
{
    public class NavigationViewModel2 : ObservableObject
    {
        #region Fields

        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        #endregion

        public NavigationViewModel2()
        {
            // Add available pages
            //PageViewModels.Add(new HomeViewModel());
            //PageViewModels.Add(new ProductsViewModel());

            // Set starting page
            //CurrentPageViewModel = PageViewModels[0];
        }
    }
}
