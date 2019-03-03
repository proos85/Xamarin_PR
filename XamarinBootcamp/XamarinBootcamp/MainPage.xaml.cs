using System;
using Xamarin.Forms;

namespace XamarinBootcamp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            UserName.Text = "";
            UserPassword.Text = "";

            SizeChanged += Pagina3_SizeChanged;
            SetOrientationState();
        }

        protected override void OnDisappearing()
        {
            SizeChanged -= Pagina3_SizeChanged;
        }

        private void Pagina3_SizeChanged(object sender, EventArgs e)
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

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (UserName.Text.Equals("KPN", StringComparison.InvariantCulture) &&
                UserPassword.Text.Equals("12345", StringComparison.InvariantCulture))
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
