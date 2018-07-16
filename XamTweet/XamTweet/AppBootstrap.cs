using ReactiveUI;
using Splat;
using Xamarin.Forms;
using XamTweet.Contracts;
using XamTweet.Forms.Services;
using XamTweet.Forms.Views;
using XamTweet.ViewModel;

namespace XamTweet.Forms
{
    public class AppBootstrap
    {
        public AppBootstrap()
        {
            InitServices();
            InitViews();
        }

        private void InitServices()
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => new NavigationService(), typeof(INavigationService));
        }

        private void InitViews()
        {
            Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
        }

        public Page MainView()
        {
            return new MainView();
        }
    }
}