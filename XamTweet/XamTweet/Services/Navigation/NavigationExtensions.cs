using ReactiveUI;
using Splat;
using System;
using Xamarin.Forms;
using XamTweet.Contracts;

namespace XamTweet.Forms.Services
{
    public static class NavigationExtensions
    {
        public static Page GetView<T>(this T viewModel) where T : class, IViewModel
        {
            var view = Locator.Current.GetService<IViewFor<T>>();

            if (view == null)
                throw new Exception("Quillo, registra la vista en AppBootstrap para que funcione");

            view.ViewModel = viewModel;

            var page = (Page)view;
            if (page == null)
                throw new TypeAccessException("Quillo, tiene que ser de tipo Page.");

            return page;
        }
    }
}