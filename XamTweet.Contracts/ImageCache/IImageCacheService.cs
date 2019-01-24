namespace XamTweet.Contracts
{
    using System.Collections.Generic;

    public interface IImageCacheService
    {
        List<CachedImage> Cache { get; }
        void Add(CachedImage cachedImage);
    }
}
