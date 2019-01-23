namespace XamTweet.Forms.Views.Cells
{
    using ReactiveUI;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetCell
    {
        public TweetCell()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.FullText, v => v.MainText.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.CreatedBy,
                    v => v.TweetUserImage.Source, url => ImageSource.FromUri(new Uri(url))));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Favorited, v => v.Like.Source,
                    arg => arg ? ImageSource.FromFile("Like.png") : ImageSource.FromFile("LikeEmpty.png")));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.FavoriteCount, v => v.FavoritesCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Replies, v => v.ReplyCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Retweets, v => v.RetweetCount.Text));
            });
        }
    }
}