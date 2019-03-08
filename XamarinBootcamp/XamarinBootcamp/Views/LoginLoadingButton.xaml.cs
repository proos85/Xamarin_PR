using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBootcamp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginLoadingButton
    {
        public static readonly BindableProperty LoginButtonCommandProperty = BindableProperty.Create(
            nameof(LoginButtonCommand),
            typeof(ICommand),
            typeof(LoginLoadingButton),
            null,
            BindingMode.TwoWay,
            propertyChanged: LoginButtonCommandPropertyChanged);

        private static void LoginButtonCommandPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var loginLoadingButton = (LoginLoadingButton) bindable;
            var command = (ICommand) newvalue;
            loginLoadingButton.LoginButton.Command = command;
        }

        public ICommand LoginButtonCommand
        {
            get => (ICommand) GetValue(LoginButtonCommandProperty);
            set => SetValue(LoginButtonCommandProperty, value);
        }

        public Color LoginButtonColor
        {
            set => LoginButtonContainer.BackgroundColor = value;
        }
        
        public Color LoginButtonTextColor
        {
            set => LoginButton.TextColor = value;
        }

        private string _loginButtonText = "Login";
        public string LoginButtonText
        {
            get => _loginButtonText;
            set
            {
                _loginButtonText = value;
                LoginButton.Text = _loginButtonText;
            }
        }

        public LoginLoadingButton ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<object>(this, "LoginCompleted", Callback);

            LoginButton.Clicked += LoginButton_Clicked;
            // Todo: Should receive from page when OnDisappearing -> remove event
        }

        private void Callback(object obj)
        {
            SetButtonText("Login");
            ToggleLoadingIndicator();
        }

        private void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            SetButtonText("Loading");
            ToggleLoadingIndicator();
        }

        private void SetButtonText(string buttonText)
        {
            LoginButtonText = buttonText;
        }

        private void ToggleLoadingIndicator()
        {
            LoginLoadingActivityIndicator.IsRunning = !LoginLoadingActivityIndicator.IsRunning;
            LoginLoadingActivityIndicator.IsEnabled = !LoginLoadingActivityIndicator.IsEnabled;
            LoginLoadingActivityIndicator.IsVisible = !LoginLoadingActivityIndicator.IsVisible;
        }
    }
}