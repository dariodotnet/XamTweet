namespace XamTweet.Contracts
{
    using DynamicData;
    using System;
    using Tweetinvi.Models;

    public interface ITwitterService
    {
        SourceList<StoredTweet> Tweets { get; }

        IObservable<ITweet> PublishTweet(string tweet);
        IObservable<ITweet> UpdateTweet(long id);

        void SetSelected(ITweet tweet);
    }
}