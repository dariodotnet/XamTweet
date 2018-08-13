using Xamarin.Forms.Xaml;

namespace XamTweet.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            //this.WhenActivated(disposables =>
            //{
            //    this.WhenAnyValue(v => v.ViewModel.LoginCommand).Where(x => x != null)
            //        .Select(x => Unit.Default)
            //        .InvokeCommand(ViewModel.LoginCommand)
            //        .DisposeWith(disposables);

            //    //this.Bind(ViewModel, vm => vm.TweetText, v => v.TweetText.Text).DisposeWith(disposables);
            //    //this.BindCommand(ViewModel, vm => vm.PublisCommand, v => v.TweetPublish);

            //    this.OneWayBind(ViewModel, vm => vm.Timeline, v => v.Timeline.ItemsSource,
            //        arg => arg.ToList().Select(x => new TweetViewModel { Tweet = x })).DisposeWith(disposables);
            //});
        }
    }
}