namespace XamTweet
{
    using System;

    public class StoredTweet
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool Favorited { get; set; }
        public int FavoriteCount { get; set; }
        public int Replies { get; set; }
        public int Retweets { get; set; }
        public string FullText { get; set; }
    }
}