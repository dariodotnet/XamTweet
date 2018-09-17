using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.Services
{
    public class TwitterService : ITwitterService
    {
        //Implementar listado de ITweets para navegar a la profundidad necesaria del stack

        //public ITweet Tweet { get; private set; }
        public List<ITweet> Tweets { get; private set; }

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
            //return Observable.Return(Tweet.PublishTweet(tweet));
            return null;
        }

        public IObservable<ITweet> UpdateTweet(long id)
        {
            Debug.WriteLine($"Pidiendo informacion sobre el tweet: {id} a las {DateTime.Now}");
            return Observable.Return(Tweetinvi.Tweet.GetTweet(id));
        }

        public void SetSelected(ITweet tweet)
        {
            if (Tweets == null)
                Tweets = new List<ITweet>();
            Tweets.Add(tweet);
        }
    }
}