namespace XamTweet.Services
{
    using Base;
    using Contracts;
    using DynamicData;
    using System;
    using System.Diagnostics;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using Tweetinvi;
    using Tweetinvi.Models;

    public class TwitterService : ITwitterService
    {
        private readonly Subject<ITwitterCredentials> credentials = new Subject<ITwitterCredentials>();

        public SourceList<ITweet> Tweets { get; }

        public TwitterService()
        {
            Tweets = new SourceList<ITweet>();

            credentials.Subscribe(c => GetTimeLine());

            Login();
        }

        private void Login()
        {
            credentials.OnNext(Auth.SetUserCredentials(AppKeys.ConsumerKey, AppKeys.ConsumerSecret,
                AppKeys.UserAccessToken, AppKeys.UserAccessSecret));
        }

        private void GetTimeLine()
        {
            Tweets.AddRange(Timeline.GetHomeTimeline());
        }

        public IObservable<ITweet> PublishTweet(string tweet)
        {
            //return Observable.Return(Tweet.PublishTweet(tweet));
            return null;
        }

        public IObservable<ITweet> UpdateTweet(long id)
        {
            Debug.WriteLine($"Pidiendo informacion sobre el tweet: {id} a las {DateTime.Now}");
            return Observable.Return(Tweet.GetTweet(id));
        }

        public void SetSelected(ITweet tweet)
        {
            //Tweets.Add(tweet);
        }
    }
}