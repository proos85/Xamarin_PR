using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinBootcamp.Droid.Effects;

[assembly: ResolutionGroupName("KPNConferencing")]
[assembly: ExportEffect(typeof(ImageFilterEffect), nameof(ImageFilterEffect))]
namespace XamarinBootcamp.Droid.Effects
{
    public class ImageFilterEffect: PlatformEffect
    {
        protected override void OnAttached()
        {
            ImageView imageView = (ImageView)Control;
            imageView.SetColorFilter(Color.FromRgb(255,255,255).ToAndroid());
        }

        protected override void OnDetached()
        {
            ImageView imageView = (ImageView)Control;
            imageView.ClearColorFilter();
        }
    }
}