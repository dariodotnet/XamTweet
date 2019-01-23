using ReactiveUI;
using System.Reactive.Disposables;
using Xamarin.Forms.Xaml;

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
                this.OneWayBind(ViewModel, vm => vm.TimeLine, v => v.Timeline.ItemsSource).DisposeWith(disposables);
            });
        }
    }
}