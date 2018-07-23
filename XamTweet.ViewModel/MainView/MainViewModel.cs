using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Reactive.Linq;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.ViewModel
{
    public class MainViewModel : NavigationViewModel
    {
        private readonly ITwitterService _twitterService;

        [Reactive] public string TweetText { get; set; }
        public extern ITweet PublishedTweet { [ObservableAsProperty] get; }

        public ReactiveCommand LoadCommand { get; }
        public ReactiveCommand<string, ITweet> PublisCommand { get; }

        public MainViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            LoadCommand = ReactiveCommand.CreateFromObservable(_twitterService.Login);

            var canPublish = this.WhenAny(x => x.TweetText, t => !string.IsNullOrEmpty(t.Value) && t.Value.Length > 5);
            PublisCommand = ReactiveCommand.CreateFromObservable<string, ITweet>(
                (x) => _twitterService.PublishTweet(TweetText), canPublish);
            PublisCommand.ToPropertyEx(this, x => x.PublishedTweet);

            this.WhenAnyValue(x => x.PublishedTweet)
                .Where(x => x != null)
                .Do(x => TweetText = "")
                .Subscribe();
        }
    }
}