using Xamarin.Forms;

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
            var page = (Page) _loginButton.Parent.Parent.Parent.Parent.Parent.Parent;
            await page.DisplayAlert("", "I'm clicked", "OK");
        }
    }
}