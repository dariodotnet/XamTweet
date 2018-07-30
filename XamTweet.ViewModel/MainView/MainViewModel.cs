using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.ViewModel
{
    public class MainViewModel : NavigationViewModel
    {
        private readonly ITwitterService _twitterService;

        [Reactive] public string TweetText { get; set; }
        public extern ITwitterCredentials Credentials { [ObservableAsProperty] get; }
        public extern ITweet PublishedTweet { [ObservableAsProperty] get; }
        public extern IEnumerable<ITweet> Timeline { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, ITwitterCredentials> LoginCommand { get; }
        public ReactiveCommand<Unit, IEnumerable<ITweet>> TimelineCommand { get; }
        public ReactiveCommand<string, ITweet> PublisCommand { get; }

        public MainViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            LoginCommand = ReactiveCommand.CreateFromObservable(_twitterService.Login);
            LoginCommand.ToPropertyEx(this, x => x.Credentials);

            TimelineCommand = ReactiveCommand.CreateFromObservable(_twitterService.GetTimeline);
            TimelineCommand.ToPropertyEx(this, x => x.Timeline);

            this.WhenAnyValue(x => x.Credentials).Where(x => x != null)
                .Select(x => Unit.Default)
                .InvokeCommand(TimelineCommand);

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