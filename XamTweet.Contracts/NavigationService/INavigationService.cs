using System;
using System.Reactive;

namespace XamTweet.Contracts
{
    public interface INavigationService
    {
        void LoadMainView<T>() where T : class, IViewModel;
        IObservable<Unit> Push<T>() where T : class, IViewModel;
        void LoadMainView();
    }
}