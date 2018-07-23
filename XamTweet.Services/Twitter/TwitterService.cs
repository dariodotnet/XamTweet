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
            Auth.SetUserCredentials("UVht5bIEPfPy92X4NhSPyoUUh", "cWsJJ3jdXOJJfiCW7JnqnSvxcC00o5DmwoV1szKn8jMoFWAEI0",
                "184009490-e7veAUSvHbRIQ4xo52TGSBMRabSi1iq5ziiue4ZE", "x1YKaW6BLWhGQdwONee8HihbHaPgIJ4q1aRjEHj454At7");
            return Observable.Return(Unit.Default);
        }

        public IObservable<ITweet> PublishTweet(string tweet)
        {
            return Observable.Return(Tweet.PublishTweet(tweet));
        }
    }
}