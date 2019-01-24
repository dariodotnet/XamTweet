namespace XamTweet.Forms.Views.Controls
{
    using Contracts;
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    using Splat;
    using System.Linq;
    using System.Reflection;
    using Xamarin.Forms;

    public class CachedImageControl : Grid
    {
        private readonly IImageCacheService _imageCacheService;

        private SKBitmap _imageBitmap;
        private readonly SKCanvasView _canvasView = new SKCanvasView();

        public CachedImageControl()
        {
            _imageCacheService = Locator.Current.GetService<IImageCacheService>();

            Children.Add(_canvasView);

            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }

        public static readonly BindableProperty ResourceProperty = BindableProperty.Create(
            nameof(Resource), typeof(Resource), typeof(CachedImageControl), default(Resource), propertyChanged: ResourceChanged);

        private static void ResourceChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((CachedImageControl)bindable).GetImage();
            ((CachedImageControl)bindable)._canvasView.InvalidateSurface();
        }

        private void GetImage()
        {
            _imageBitmap?.Dispose();
            XamTweet.CachedImage cached = new CachedImage();
            switch (Resource)
            {
                case Resource.Like:
                    cached = Get(XamTweet.Forms.Resources.Images.Image.Like);
                    break;
                case Resource.LikeEmpty:
                    cached = Get(XamTweet.Forms.Resources.Images.Image.LikeEmpty);
                    break;
                case Resource.Reply:
                    cached = Get(XamTweet.Forms.Resources.Images.Image.Reply);
                    break;
                case Resource.Retweet:
                    cached = Get(XamTweet.Forms.Resources.Images.Image.Retweet);
                    break;
                case Resource.Share:
                    cached = Get(XamTweet.Forms.Resources.Images.Image.Share);
                    break;
            }
            _imageBitmap = SKBitmap.Decode(cached.Bytes);
        }

        private CachedImage Get(string resource)
        {
            return _imageCacheService.Cache.FirstOrDefault(x => x.Id.Equals(resource)) ??
                   GetResource(resource);
        }

        private CachedImage GetResource(string resource)
        {
            using (var stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(resource))
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);

                var cache = new XamTweet.CachedImage
                {
                    Id = resource,
                    Bytes = bytes
                };
                _imageCacheService.Add(cache);
                return cache;
            }
        }

        public Resource Resource
        {
            get => (Resource)GetValue(ResourceProperty);
            set => SetValue(ResourceProperty, value);
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (_imageBitmap is null)
                return;

            var canvas = e.Surface.Canvas;
            canvas.Clear();

            canvas.DrawBitmap(_imageBitmap, canvas.LocalClipBounds);
        }
    }


}