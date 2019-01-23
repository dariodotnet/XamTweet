using DynamicData;
using System;
using Tweetinvi.Models;

namespace XamTweet.Contracts
{
    public interface ITwitterService
    {
        SourceList<ITweet> Tweets { get; }

        IObservable<ITweet> PublishTweet(string tweet);
        IObservable<ITweet> UpdateTweet(long id);

        void SetSelected(ITweet tweet);
    }
}