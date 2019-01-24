namespace XamTweet.Forms.Views.Cells
{
    using ReactiveUI;
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
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.CreatedBy, v => v.TweetUserImage.Contact));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Favorited, v => v.Like.Resource,
                    arg => arg ? Resource.Like : Resource.LikeEmpty));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.FavoriteCount, v => v.FavoritesCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Replies, v => v.ReplyCount.Text));
                disposables(this.OneWayBind(ViewModel, vm => vm.Tweet.Retweets, v => v.RetweetCount.Text));
            });
        }
    }
}