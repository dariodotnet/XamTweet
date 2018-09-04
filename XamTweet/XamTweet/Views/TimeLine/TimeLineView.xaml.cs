using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms.Xaml;
using XamTweet.ViewModel;

namespace XamTweet.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeLineView
    {
        public TimeLineView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(v => v.ViewModel.LoginCommand).Where(x => x != null)
                    .Select(x => Unit.Default)
                    .InvokeCommand(ViewModel.LoginCommand)
                    .DisposeWith(disposables);

                this.OneWayBind(ViewModel, vm => vm.Timeline, v => v.Timeline.ItemsSource,
                    arg => arg.ToList().Select(x => new TweetViewModel { Tweet = x })).DisposeWith(disposables);
            });
        }
    }
}