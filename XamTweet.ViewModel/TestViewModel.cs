using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace XamTweet.ViewModel
{
    public class TestViewModel : ReactiveObject
    {
        [Reactive] public string Name { get; set; }

        public extern bool IsBusy { [ObservableAsProperty] get; }

        public ReactiveCommand LoadTweetCommand { get; }

        public TestViewModel()
        {
            LoadTweetCommand = ReactiveCommand.Create(() =>
            {

            });

            LoadTweetCommand.IsExecuting.ToPropertyEx(this, x => x.IsBusy);
        }
    }
}