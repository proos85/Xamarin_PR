using System.Linq;
using Xamarin.Forms;
using XamarinBootcamp.Services;

namespace XamarinBootcamp.Behaviours
{
    public class ShowMessageWhenClickedButtonBehaviour: Behavior<Button>
    {
        private Button _loginButton;

        protected override void OnAttachedTo(Button loginButton)
        {
            _loginButton = loginButton;
            _loginButton.Clicked += LoginButton_Clicked;
        }

        protected override void OnDetachingFrom(Button loginButton)
        {
            _loginButton.Clicked -= LoginButton_Clicked;
        }

        private async void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            var mainPage = (NavigationPage)Application.Current.MainPage;
            var page = mainPage.Pages.ElementAt(0);
            
            var localMessage = DependencyService.Get<IDisplayService>().GetMessage();
            await page.DisplayAlert("", localMessage, "OK");
            
            var platformMessage = DependencyService.Get<IDisplayServicePlatform>().GetMessage();
            await page.DisplayAlert("", platformMessage, "OK");
        }
    }
}