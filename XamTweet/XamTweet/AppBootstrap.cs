using ReactiveUI;
using Splat;
using XamTweet.Contracts;
using XamTweet.Forms.Services;
using XamTweet.Forms.Views;
using XamTweet.Services;
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
            Locator.CurrentMutable.RegisterLazySingleton(() => new TwitterService(), typeof(ITwitterService));
        }

        private void InitViews()
        {
            Locator.CurrentMutable.Register(() => new MainView(), typeof(IViewFor<MainViewModel>));
        }

        public void MainView()
        {
            var _navigator = Locator.Current.GetService<INavigationService>();

            _navigator.LoadMainView<MainViewModel>();
        }
    }
}