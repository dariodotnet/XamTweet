namespace XamTweet.ViewModel
{
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;

    public class TweetViewModel : ReactiveObject
    {
        [Reactive] public StoredTweet Tweet { get; set; }

        public TweetViewModel()
        {
        }
    }
}