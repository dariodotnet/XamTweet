using System;
using System.Collections.Generic;
using Tweetinvi.Models;

namespace XamTweet.Contracts
{
    public interface ITwitterService
    {
        IObservable<ITwitterCredentials> Login();
        IObservable<IEnumerable<ITweet>> GetTimeline();
        IObservable<ITweet> PublishTweet(string tweet);
    }
}