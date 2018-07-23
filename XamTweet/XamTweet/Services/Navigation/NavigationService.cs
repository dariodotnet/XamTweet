using System;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using XamTweet.Contracts;

namespace XamTweet.Forms.Services
{
    public class NavigationService : INavigationService
    {
        public void LoadMainView<T>() where T : class, IViewModel
        {
            var ctor = typeof(T).GetTypeInfo().DeclaredConstructors.First();
            var args = new object[ctor.GetParameters().Count()];
            var viewModel = (T)Activator.CreateInstance(typeof(T), args);

            Application.Current.MainPage = viewModel.GetView();
        }

        public INavigation Navigator => ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation;
    }
}