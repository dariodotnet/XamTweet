namespace XamTweet.ViewModel
{
    using Contracts;
    using DynamicData;
    using Splat;
    using System;
    using System.Collections.ObjectModel;

    public class TimeLineViewModel : NavigationViewModel
    {
        private readonly ITwitterService _twitterService;

        private readonly ReadOnlyObservableCollection<TweetViewModel> timeLine;
        public ReadOnlyObservableCollection<TweetViewModel> TimeLine => timeLine;

        public TimeLineViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            _twitterService.Tweets.Connect()
                .Transform(t => new TweetViewModel { Tweet = t })
                .Bind(out timeLine)
                .DisposeMany().Subscribe();
        }
    }
}