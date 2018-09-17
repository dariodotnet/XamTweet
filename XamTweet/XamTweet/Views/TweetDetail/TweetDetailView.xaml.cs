using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTweet.ViewModel.TweetDetail;

namespace XamTweet.Forms.Views.TweetDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetDetailView : ReactiveContentPage<TweetDetailViewModel>
    {
        public TweetDetailView()
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

                //disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Favorited, v => v.TapFavorite.CommandParameter));

                disposables(this.BindCommand(ViewModel, vm => vm.FavoriteCommand, v => v.TapFavorite));
            });
        }
    }
}