namespace XamTweet.Contracts
{
    using System;

    public interface IStorageService
    {
        IObservable<T> GetObject<T>(string key);
        IObservable<T> InsertObject<T>(string key, T data, DateTimeOffset? absoluteExpiration = null);
    }
}
