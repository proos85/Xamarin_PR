using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBootcamp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage ()
        {
            InitializeComponent();
        }
    }
}