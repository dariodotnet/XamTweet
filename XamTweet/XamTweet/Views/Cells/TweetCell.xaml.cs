using ReactiveUI;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamTweet.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetCell
    {
        public TweetCell()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.FullText, v => v.MainText.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.CreatedBy.ProfileImageUrlHttps,
                    v => v.TweetUserImage.Source, url => ImageSource.FromUri(new Uri(url))));
                disposables(this.OneWayBind(ViewModel, vm => vm.Favorited, v => v.Like.Source,
                    arg => arg ? ImageSource.FromFile("Like.png") : ImageSource.FromFile("LikeEmpty.png")));
                disposables(this.OneWayBind(ViewModel, vm => vm.FavoriteCount, v => v.FavoritesCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Replies, v => v.ReplyCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Retweets, v => v.RetweetCount.Text));

                //disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Favorited, v => v.TapFavorite.CommandParameter));

                disposables(this.BindCommand(ViewModel, vm => vm.FavoriteCommand, v => v.TapFavorite));
            });
        }
    }
}