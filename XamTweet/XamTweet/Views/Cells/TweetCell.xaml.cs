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
            });
        }
    }
}