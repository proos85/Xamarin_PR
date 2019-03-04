using Xamarin.Forms.Xaml;

namespace XamarinBootcamp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMenuPage
    {
        public MasterMenuPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            App.SetMainPage<LoginPage>(true);
        }
    }
}