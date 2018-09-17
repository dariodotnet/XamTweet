using Splat;
using XamTweet.Contracts;

namespace XamTweet.ViewModel
{
    public class NavigationViewModel : BaseViewModel, IViewModel
    {
        public INavigationService Navigator { get; }

        public NavigationViewModel()
        {
            Navigator = Locator.Current.GetService<INavigationService>();
        }
    }
}