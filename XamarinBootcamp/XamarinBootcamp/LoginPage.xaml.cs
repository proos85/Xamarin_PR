using System;
using Xamarin.Forms;

namespace XamarinBootcamp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            UserName.Text = "";
            UserPassword.Text = "";

            SizeChanged += LoginPage_SizeChanged;
            SetOrientationState();

            MessagingCenter.Subscribe<object,bool>(this, "Login", Login_Callback);
        }

        protected override void OnDisappearing()
        {
            SizeChanged -= LoginPage_SizeChanged;
            MessagingCenter.Unsubscribe<object, bool>(this, "Login");
        }

        private void LoginPage_SizeChanged(object sender, EventArgs e)
        {
            SetOrientationState();
        }

        private void SetOrientationState()
        {
            var visualState = Width > Height ? "Landscape" : "Portrait";

            VisualStateManager.GoToState(KpnLogo, $"KpnLogo{visualState}");
            VisualStateManager.GoToState(MyFrame, $"MyFrame{visualState}");
            VisualStateManager.GoToState(AuthStackLayout, $"AuthStackLayout{visualState}");
        }

        private async void Login_Callback(
            object _, 
            bool loginStatus)
        {
            if (loginStatus)
            {
                await DisplayAlert("Horay", "You're in", "OK");
                await Navigation.PushAsync(new Pagina2(), true);
            }
            else
            {
                await DisplayAlert(":-(", "Helaas", "OK");
            }
        }
    }
}
