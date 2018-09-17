using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using XamTweet.Contracts;
using XamTweet.ViewModel;

namespace XamTweet.Forms.Services
{
    public class NavigationService : INavigationService
    {
        //Implementar gestion de errores

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
            var menu = new MenuViewModel().GetView();
            menu.Title = " ";
            menu.Icon = "Menu.png";

            var masterDetail = new MasterDetailPage
            {
                Detail = new MainViewModel().GetView(),
                Master = menu
            };

            Application.Current.MainPage = masterDetail;
        }

        public INavigation Navigator => ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation;
    }
}