using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi.Models;

namespace XamTweet.ViewModel
{
    public class TweetViewModel : ReactiveObject
    {

        //crear propiedades observables para gestionar el estado del tweet

        [Reactive] public ITweet Tweet { get; set; }

        [Reactive] public bool Favorited { get; set; }
        [Reactive] public int FavoriteCount { get; set; }

        public ReactiveCommand FavoriteCommand { get; }

        public TweetViewModel()
        {
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