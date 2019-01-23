using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.ViewModel.TweetDetail
{
    public class TweetDetailViewModel : NavigationViewModel
    {
        private readonly ITwitterService _twitterService;

        [Reactive] public ITweet Tweet { get; set; }

        [Reactive] public bool Favorited { get; set; }
        [Reactive] public int FavoriteCount { get; set; }

        public ReactiveCommand<Unit, Unit> FavoriteCommand { get; }

        public TweetDetailViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            Tweet = _twitterService.Tweets.LastOrDefault();

            FavoriteCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                if (Tweet.Favorited)
                    await Tweet.UnFavoriteAsync();
                else
                    await Tweet.FavoriteAsync();

                Favorited = Tweet.Favorited;
                FavoriteCount = Tweet.Favorited ?
                    FavoriteCount = Tweet.FavoriteCount + 1 :
                    FavoriteCount = Tweet.FavoriteCount;

                return Unit.Default;
            });

            this.WhenAnyValue(x => x.Tweet).Where(x => x != null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(tweet =>
                {
                    Favorited = tweet.Favorited;
                    FavoriteCount = tweet.FavoriteCount;
                });
        }
    }
}