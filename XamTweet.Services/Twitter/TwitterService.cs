using System;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.Services
{
    public class TwitterService : ITwitterService
    {
        public IObservable<Unit> Login()
        {
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            return Observable.Return(Unit.Default);
        }

        public IObservable<ITweet> PublishTweet(string tweet)
        {
            return Observable.Return(Tweet.PublishTweet(tweet));
        }
    }
}