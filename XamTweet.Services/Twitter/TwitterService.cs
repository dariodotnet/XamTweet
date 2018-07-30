using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.Services
{
    public class TwitterService : ITwitterService
    {
        public IObservable<ITwitterCredentials> Login()
        {
            return Observable.Return(Auth.SetUserCredentials("wq84QNPdAsF7P88DPbvAhNZa1",
                "xVtP7QRl8YqpTBAmecoSOsi1o0IvsleybdNQvs6mxCtJp08pOZ",
                "184009490-e7veAUSvHbRIQ4xo52TGSBMRabSi1iq5ziiue4ZE",
                "x1YKaW6BLWhGQdwONee8HihbHaPgIJ4q1aRjEHj454At7"));
        }

        public IObservable<IEnumerable<ITweet>> GetTimeline()
        {
            return Observable.Return(Timeline.GetHomeTimeline());
        }

        public IObservable<ITweet> PublishTweet(string tweet)
        {
            return Observable.Return(Tweet.PublishTweet(tweet));
        }
    }
}