using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinBootcamp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuperHeroesPage
    {
		public SuperHeroesPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<object>(this, "AddHero", OnSuperHeroAdded);
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<object>(this, "AddHero");
        }

        private void OnSuperHeroAdded(object obj)
        {
            AddSuperHeroToolbarItem_Clicked(this, null);
        }

        private void AddSuperHeroToolbarItem_Clicked(object sender, EventArgs e)
        {
            AddHeroLayer.IsVisible = !AddHeroLayer.IsVisible;
            AddHeroPanel.IsVisible = !AddHeroPanel.IsVisible;
        }

        private async void ShowInfo_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Superheroes URI", "https://comicvine.gamespot.com/profile/lvenger/lists/my-100-favourite-superheroes/17520/", "OK");
        }
    }
}