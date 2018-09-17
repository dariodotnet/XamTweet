using System;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace XamTweet.Contracts
{
    public interface ITwitterService
    {
        List<ITweet> Tweets { get; }

        IObservable<ITwitterCredentials> Login();
        IObservable<IEnumerable<ITweet>> GetTimeline();
        IObservable<ITweet> PublishTweet(string tweet);
        IObservable<ITweet> UpdateTweet(long id);

        void SetSelected(ITweet tweet);
    }
}