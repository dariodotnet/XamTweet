using ReactiveUI;
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
                    disposables(this.OneWayBind(ViewModel, vm => vm.TimeLine, v => v.TimeLineView.ViewModel));
                });
        }
    }
}