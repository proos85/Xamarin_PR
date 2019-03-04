using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBootcamp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail
    {
        public MainPageDetail()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var mdp = ((NavigationPage) Application.Current.MainPage).Pages.OfType<MasterDetailPage>().FirstOrDefault();
            if (mdp != null) mdp.IsPresented = true;
        }

        private async void Button2_OnClicked(object sender, EventArgs e)
        {
            var page = new ContentPage
            {
                Title = "Test",
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Ik ben er",
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.CenterAndExpand
                        }
                    }
                }
            };

            await Navigation.PushAsync(page, true);
        }
    }
}