using ReactiveUI;
using Splat;
using XamTweet.Contracts;
using XamTweet.Forms.Services;
using XamTweet.Forms.Views;
using XamTweet.Forms.Views.TweetDetail;
using XamTweet.Services;
using XamTweet.ViewModel;
using XamTweet.ViewModel.TweetDetail;

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
            Locator.CurrentMutable.Register(() => new MenuView(), typeof(IViewFor<MenuViewModel>));
            Locator.CurrentMutable.Register(() => new TimeLineView(), typeof(IViewFor<TimeLineViewModel>));
            Locator.CurrentMutable.Register(() => new SearchView(), typeof(IViewFor<SearchViewModel>));
            Locator.CurrentMutable.Register(() => new NotificationsView(), typeof(IViewFor<NotificationsViewModel>));
            Locator.CurrentMutable.Register(() => new MessagesView(), typeof(IViewFor<MessagesViewModel>));
            Locator.CurrentMutable.Register(() => new TweetDetailView(), typeof(IViewFor<TweetDetailViewModel>));
        }

        public void MainView()
        {
            var _navigator = Locator.Current.GetService<INavigationService>();

            _navigator.LoadMainView();
        }
    }
}