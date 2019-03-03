using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBootcamp.ViewModels
{
    public class LoginPageViewModel: ViewModelBase
    {
        private string _loginUserName;
        private string _loginPassword;

        public string LoginUserName
        {
            get => _loginUserName;
            set
            {
                if (LoginUserName == value)
                {
                    return;
                }

                OnPropertyChanged(nameof(LoginUserName));
                _loginUserName = value;
            }
        }

        public string LoginPassword
        {
            get => _loginPassword;
            set
            {
                if (LoginPassword == value)
                {
                    return;
                }

                OnPropertyChanged(nameof(LoginPassword));
                _loginPassword = value;
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(DoLogin);
        }

        private void DoLogin()
        {
            bool loginStatus = LoginUserName.Equals("KPN", StringComparison.InvariantCulture) &&
                               LoginPassword.Equals("12345", StringComparison.InvariantCulture);

            MessagingCenter.Send(this, "Login");
        }
    }
}