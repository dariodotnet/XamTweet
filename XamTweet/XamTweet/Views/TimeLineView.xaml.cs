using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTweet.ViewModel.TimeLine;

namespace XamTweet.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeLineView : ContentPage
    {
        public TimeLineView()
        {
            InitializeComponent();

            BindingContext = new TimeLineViewModel();
        }
    }
}