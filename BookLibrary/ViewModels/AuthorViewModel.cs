namespace BookLibrary.ViewModels
{
    public class AuthorViewModel : BaseViewModel, IPageViewModel
    {
        public string Name
        {
            get { return "Authors"; }
        }

        public AuthorViewModel() { }
    }
}
