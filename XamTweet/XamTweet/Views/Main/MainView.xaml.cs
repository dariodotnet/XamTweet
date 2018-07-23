using System.Reactive;
using ReactiveUI;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Xamarin.Forms.Xaml;

namespace XamTweet.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView
    {
        public MainView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(v => v.ViewModel.LoadCommand).Where(x => x != null)
                    .Select(x => Unit.Default)
                    .InvokeCommand(ViewModel.LoadCommand)
                    .DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.TweetText, v => v.TweetText.Text).DisposeWith(disposables);
                this.BindCommand(ViewModel, vm => vm.PublisCommand, v => v.TweetPublish);
            });
        }
    }
}