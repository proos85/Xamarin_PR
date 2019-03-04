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

                ((Command)LoginCommand).ChangeCanExecute();
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

                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(DoLogin, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand()
        {
            var canExecute = !string.IsNullOrWhiteSpace(LoginUserName) && !string.IsNullOrWhiteSpace(LoginPassword);
            return canExecute;
        }

        private void DoLogin()
        {
            bool loginStatus = LoginUserName.Equals("KPN", StringComparison.InvariantCulture) &&
                               LoginPassword.Equals("12345", StringComparison.InvariantCulture);

            MessagingCenter.Send<object,bool>(this, "Login", loginStatus);
        }
    }
}