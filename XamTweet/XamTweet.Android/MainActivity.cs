
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace XamTweet.Droid
{
    [Activity(Label = "XamTweet", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new Forms.App());
        }
    }
}

