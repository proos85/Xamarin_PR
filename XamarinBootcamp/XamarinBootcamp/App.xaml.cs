using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBootcamp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinBootcamp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage<LoginPage>();

            RegisterServices();
        }

        private void RegisterServices()
        {
            DependencyService.Register<IDisplayService, DisplayService>();
            DependencyService.Register<IDisplayServicePlatform>();
        }

        public static void SetMainPage<TPage>(bool isMainNavigationPage = true) where TPage: Page, new()
        {
            if (!isMainNavigationPage)
            {
                Current.MainPage = new TPage();
            }
            else
            {
                Current.MainPage = new NavigationPage(new TPage())
                {
                    BarBackgroundColor = Color.FromRgb(0, 153, 0),
                    BarTextColor = Color.White
                };
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
