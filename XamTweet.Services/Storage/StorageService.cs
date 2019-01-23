using XamTweet.Contracts;

namespace XamTweet.Services
{
    using Akavache;
    using System;
    using System.Collections.Generic;
    using System.Reactive.Linq;

    public class StorageService : IStorageService
    {
        private readonly IBlobCache blob;

        public StorageService()
        {
            BlobCache.ApplicationName = "xam_tweet";
            BlobCache.EnsureInitialized();
            BlobCache.ForcedDateTimeKind = DateTimeKind.Utc;
            blob = BlobCache.LocalMachine;
        }

        public IObservable<T> GetObject<T>(string key)
        {
            try
            {
                return blob.GetObject<T>(key);
            }
            catch (KeyNotFoundException)
            {
                return Observable.Return(default(T));
            }
        }

        public IObservable<T> InsertObject<T>(string key, T data, DateTimeOffset? absoluteExpiration = null) =>
            blob.InsertObject(key, data, absoluteExpiration).SelectMany(x => GetObject<T>(key));

        public IObservable<IEnumerable<T>> GetAllObjects<T>() => blob.GetAllObjects<T>();
    }
}