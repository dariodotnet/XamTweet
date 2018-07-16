using ReactiveUI;
using System;
using System.Reactive;

namespace XamTweet.ViewModel
{
    public class BaseViewModel : ReactiveObject
    {
        public Interaction<Exception, Unit> ErrorInteraction { get; }

        public BaseViewModel()
        {
            ErrorInteraction = new Interaction<Exception, Unit>();
        }


    }
}