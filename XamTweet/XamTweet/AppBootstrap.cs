namespace XamTweet.Forms
{
    using Contracts;
    using ReactiveUI;
    using Services;
    using Splat;
    using ViewModel;
    using ViewModel.TweetDetail;
    using Views;
    using XamTweet.Services;

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
            Locator.CurrentMutable.RegisterLazySingleton(() => new StorageService(), typeof(IStorageService));
            Locator.CurrentMutable.RegisterLazySingleton(() => new ImageCacheService(), typeof(IImageCacheService));
        }

        private void InitViews()
        {
            Locator.CurrentMutable.Register(() => new TimeLineView(), typeof(IViewFor<TimeLineViewModel>));
            Locator.CurrentMutable.Register(() => new TweetDetailView(), typeof(IViewFor<TweetDetailViewModel>));
        }

        public void MainView()
        {
            var _navigator = Locator.Current.GetService<INavigationService>();

            _navigator.LoadMainView();
        }
    }
}