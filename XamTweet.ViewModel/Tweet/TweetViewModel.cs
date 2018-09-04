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

        public ReactiveCommand FavoriteCommand { get; }

        public TweetViewModel()
        {
            FavoriteCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await Tweet.FavoriteAsync();
                Favorited = true;
                var test = Tweet.Favorited;

                return Unit.Default;
            });

            this.WhenAnyValue(x => x.Tweet).Where(x => x != null)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(tweet =>
                {
                    Favorited = tweet.Favorited;
                });
        }
    }
}