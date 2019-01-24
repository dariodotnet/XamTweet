namespace XamTweet.Services
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class ImageCacheService : IImageCacheService
    {
        public List<CachedImage> Cache { get; private set; }

        public ImageCacheService()
        {
            Cache = new List<CachedImage>();
        }

        public void Add(CachedImage cachedImage)
        {
            if (Cache is null)
                Cache = new List<CachedImage>();

            if (!Cache.Any(x => x.Id.Equals(cachedImage.Id)))
                Cache.Add(cachedImage);
        }
    }
}
