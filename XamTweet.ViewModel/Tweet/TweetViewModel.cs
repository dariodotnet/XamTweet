using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.ViewModel
{
    public class TweetViewModel : ReactiveObject
    {
        private readonly ITwitterService _twitterService;
        //crear propiedades observables para gestionar el estado del tweet

        [Reactive] public ITweet Tweet { get; set; }
        [Reactive] public bool Favorited { get; set; }
        [Reactive] public int FavoriteCount { get; set; }
        [Reactive] public int Retweets { get; set; }
        [Reactive] public int? Replies { get; set; }

        public ReactiveCommand<Unit, Unit> FavoriteCommand { get; }

        public ReactiveCommand<long, ITweet> UpdateTweetCommand { get; }

        public TweetViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            UpdateTweetCommand = ReactiveCommand.CreateFromObservable<long, ITweet>(x => _twitterService.UpdateTweet(x));
            UpdateTweetCommand.Subscribe(ConfigureData);

            FavoriteCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if (Tweet.Favorited)
                    await Tweet.UnFavoriteAsync();
                else
                    await Tweet.FavoriteAsync();

                Observable.Start(() => Tweet.Id).InvokeCommand(UpdateTweetCommand);

                return Unit.Default;
            });

            this.WhenAnyValue(x => x.Tweet).Where(x => x != null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(ConfigureData);
        }

        private void ConfigureData(ITweet x)
        {
            if (Tweet == x)
                return;
            Tweet = x;
            Favorited = x.Favorited;
            FavoriteCount = x.FavoriteCount;
            Replies = x.ReplyCount;
            Retweets = x.RetweetCount;
        }
    }
}