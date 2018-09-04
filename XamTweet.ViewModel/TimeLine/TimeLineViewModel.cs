using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Splat;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using Tweetinvi.Models;
using XamTweet.Contracts;

namespace XamTweet.ViewModel
{
    public class TimeLineViewModel : NavigationViewModel
    {
        private readonly ITwitterService _twitterService;

        public extern ITwitterCredentials Credentials { [ObservableAsProperty] get; }
        public extern IEnumerable<ITweet> Timeline { [ObservableAsProperty] get; }

        public ReactiveCommand<Unit, ITwitterCredentials> LoginCommand { get; }
        public ReactiveCommand<Unit, IEnumerable<ITweet>> TimelineCommand { get; }

        public TimeLineViewModel(ITwitterService twitterService = null)
        {
            _twitterService = twitterService ?? Locator.Current.GetService<ITwitterService>();

            LoginCommand = ReactiveCommand.CreateFromObservable(_twitterService.Login);
            LoginCommand.ToPropertyEx(this, x => x.Credentials);

            TimelineCommand = ReactiveCommand.CreateFromObservable(_twitterService.GetTimeline);
            TimelineCommand.ToPropertyEx(this, x => x.Timeline);

            this.WhenAnyValue(x => x.Credentials).Where(x => x != null)
                .Select(x => Unit.Default)
                .InvokeCommand(TimelineCommand);
        }
    }
}