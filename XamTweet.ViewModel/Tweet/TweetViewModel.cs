using ReactiveUI;
using Tweetinvi.Models;

namespace XamTweet.ViewModel
{
    public class TweetViewModel : ReactiveObject
    {
        public ITweet Tweet { get; set; }
    }
}