using Xamarin.Forms;
using XamTweet.Contracts;

namespace XamTweet.Forms.Services
{
    public class NavigationService : INavigationService
    {
        public INavigation Navigator => ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation;
    }
}