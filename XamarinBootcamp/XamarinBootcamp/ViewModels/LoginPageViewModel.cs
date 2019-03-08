using System;
using System.Threading.Tasks;
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

        private async void DoLogin()
        {
            bool loginStatus = LoginUserName.Equals("KPN", StringComparison.InvariantCulture) &&
                               LoginPassword.Equals("12345", StringComparison.InvariantCulture);

            await Task.Delay(5000);

            MessagingCenter.Send<object,bool>(this, "Login", loginStatus);
            MessagingCenter.Send<object>(this, "LoginCompleted");
        }
    }
}