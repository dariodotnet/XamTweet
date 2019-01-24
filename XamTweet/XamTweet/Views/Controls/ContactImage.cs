namespace XamTweet.Forms.Views.Controls
{
    using Contracts;
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    using Splat;
    using System;
    using System.Linq;
    using System.Reflection;
    using Xamarin.Forms;

    public class ContactImage : Grid
    {
        private readonly IImageCacheService _imageCacheService;
        private SKBitmap _imageBitmap;

        private SKCanvasView _canvasView = new SKCanvasView();

        public ContactImage()
        {
            _imageCacheService = Locator.Current.GetService<IImageCacheService>();

            Children.Add(_canvasView);
            _canvasView.PaintSurface += CanvasViewOnPaintSurface;
        }

        public static readonly BindableProperty ContactProperty = BindableProperty.Create(
            nameof(Contact), typeof(string), typeof(ContactImage), default(string), propertyChanged: ContactChanged);

        private static void ContactChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (string.IsNullOrEmpty((string)newvalue))
                return;

            ((ContactImage)bindable).GetContactImage();
            ((ContactImage)bindable)._canvasView.InvalidateSurface();
        }

        private void GetContactImage()
        {
            _imageBitmap?.Dispose();

            var defaultImage = XamTweet.Forms.Resources.Images.Image.DefaultUser;

            var cached = _imageCacheService.Cache.FirstOrDefault(x => x.Id.Equals(defaultImage));

            if (cached is null)
            {
                using (var stream = GetType().GetTypeInfo().Assembly
                    .GetManifestResourceStream(XamTweet.Forms.Resources.Images.Image.DefaultUser))
                {
                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, (int)stream.Length);
                    cached = new XamTweet.CachedImage
                    {
                        Id = defaultImage,
                        Bytes = bytes
                    };
                    _imageCacheService.Add(cached);
                }
            }

            _imageBitmap = SKBitmap.Decode(cached.Bytes);
        }

        public string Contact
        {
            get => (string)GetValue(ContactProperty);
            set => SetValue(ContactProperty, value);
        }

        private void CanvasViewOnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (_imageBitmap is null)
                return;

            var info = e.Info;
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            var radius = Math.Min(info.Width, info.Height) / 2f;

            var path = new SKPath();

            //TopLeft
            path.MoveTo(0, 0);
            //TopRight
            path.ArcTo(new SKPoint(info.Width, 0f), new SKPoint(info.Width, info.Height), radius);
            //BottomRight
            path.ArcTo(new SKPoint(info.Width, info.Height), new SKPoint(0f, info.Height), radius);
            //BottomLeft
            path.ArcTo(new SKPoint(0f, info.Height), new SKPoint(0f, 0f), radius);

            path.ArcTo(new SKPoint(0f, 0f), new SKPoint(info.Width, 0f), radius);
            path.Close();

            path.GetTightBounds(out var bounds);
            canvas.ClipPath(path);
            canvas.ResetMatrix();

            canvas.DrawBitmap(_imageBitmap, bounds);
        }
    }
}