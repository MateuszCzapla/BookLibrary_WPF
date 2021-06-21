namespace BookLibrary.ViewModels
{
    public class ProductsViewModel : BaseViewModel, IPageViewModel
    {
        public string Name
        {
            get { return "Products"; }
        }

        public ProductsViewModel()
        {

        }
    }
}
