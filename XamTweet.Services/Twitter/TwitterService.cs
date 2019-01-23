namespace XamTweet.Services
{
    using Base;
    using Contracts;
    using DynamicData;
    using Splat;
    using System;
    using System.Linq;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using Tweetinvi;
    using Tweetinvi.Models;

    public class TwitterService : ITwitterService
    {
        private readonly IStorageService _storageService;
        private readonly Subject<ITwitterCredentials> _credentials = new Subject<ITwitterCredentials>();

        public TwitterService(IStorageService storageService = null)
        {
            _storageService = storageService ?? Locator.Current.GetService<IStorageService>();
            Tweets = new SourceList<StoredTweet>();

            _credentials.Subscribe(c => GetTimeLine());

            Login();
        }

        public SourceList<StoredTweet> Tweets { get; }

        public IObservable<ITweet> PublishTweet(string tweet)
        {
            return null;
        }

        public IObservable<ITweet> UpdateTweet(long id)
        {
            return Observable.Return(Tweet.GetTweet(id));
        }

        public void SetSelected(ITweet tweet)
        {

        }

        private void Login()
        {
            _credentials.OnNext(Auth.SetUserCredentials(AppKeys.ConsumerKey, AppKeys.ConsumerSecret,
                AppKeys.UserAccessToken, AppKeys.UserAccessSecret));
        }

        private void GetTimeLine()
        {
            _storageService.GetAllObjects<StoredTweet>().Subscribe(tweets =>
            {
                Tweets.AddRange(tweets);
                Refresh();
            }, ex =>
            {
                Refresh();
            });
        }

        private void Refresh()
        {
            foreach (var tweet in Timeline.GetHomeTimeline())
            {
                var stored = new StoredTweet
                {
                    Id = tweet.Id,
                    CreatedAt = tweet.CreatedAt,
                    CreatedBy = tweet.CreatedBy.ProfileBackgroundImageUrlHttps,
                    FavoriteCount = tweet.FavoriteCount,
                    Favorited = tweet.Favorited,
                    FullText = tweet.FullText,
                    Replies = tweet.ReplyCount ?? 0,
                    Retweets = tweet.RetweetCount
                };
                _storageService.InsertObject(stored.Id.ToString(), stored, DateTimeOffset.UtcNow.AddDays(3))
                    .Subscribe(t =>
                    {
                        var current = Tweets.Items.FirstOrDefault(x => x.Id.Equals(t.Id));
                        if (current is null)
                            Tweets.Add(t);
                        else
                            Tweets.Replace(current, t);
                    });
            }
        }
    }
}