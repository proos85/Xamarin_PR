using XamarinBootcamp.Droid.Services;
using XamarinBootcamp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayServicePlatform))]
namespace XamarinBootcamp.Droid.Services
{
    public class DisplayServicePlatform: IDisplayServicePlatform
    {
        public string GetMessage()
        {
            return "Message from Android";
        }
    }
}