namespace XamTweet.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStorageService
    {
        IObservable<T> GetObject<T>(string key);
        IObservable<T> InsertObject<T>(string key, T data, DateTimeOffset? absoluteExpiration = null);
        IObservable<IEnumerable<T>> GetAllObjects<T>();
    }
}
