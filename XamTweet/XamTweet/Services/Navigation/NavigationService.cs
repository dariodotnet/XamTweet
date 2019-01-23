namespace XamTweet.Forms.Services
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Threading.Tasks;
    using System.Reflection;
    using ViewModel;
    using Xamarin.Forms;

    public class NavigationService : INavigationService
    {
        public void LoadMainView<T>() where T : class, IViewModel
        {
            var ctor = typeof(T).GetTypeInfo().DeclaredConstructors.First();
            var args = new object[ctor.GetParameters().Count()];
            var viewModel = (T)Activator.CreateInstance(typeof(T), args);

            Application.Current.MainPage = viewModel.GetView();
        }

        public IObservable<Unit> Push<T>() where T : class, IViewModel
        {
            try
            {
                var master = (MasterDetailPage)Application.Current.MainPage;
                var tabbed = (TabbedPage)master.Detail;
                var current = tabbed.CurrentPage.Navigation;

                var ctor = typeof(T).GetTypeInfo().DeclaredConstructors.First();
                var args = new object[ctor.GetParameters().Count()];
                var viewModel = (T)Activator.CreateInstance(typeof(T), args);

                return current.PushAsync(viewModel.GetView()).ToObservable();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void LoadMainView()
        {
            Application.Current.MainPage = new NavigationPage(new TimeLineViewModel().GetView());
        }

        public INavigation Navigator => ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation;
    }
}