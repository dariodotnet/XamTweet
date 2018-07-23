using System;
using System.Reactive;
using Tweetinvi.Models;

namespace XamTweet.Contracts
{
    public interface ITwitterService
    {
        IObservable<Unit> Login();
        IObservable<ITweet> PublishTweet(string tweet);
    }
}