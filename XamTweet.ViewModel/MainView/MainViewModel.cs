using ReactiveUI.Fody.Helpers;

namespace XamTweet.ViewModel
{
    public class MainViewModel : NavigationViewModel
    {
        [Reactive] public TimeLineViewModel TimeLine { get; set; }

        public MainViewModel()
        {
            TimeLine = new TimeLineViewModel();
        }
    }
}