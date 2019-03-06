using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinBootcamp.Effects;

namespace XamarinBootcamp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuperHeroesPage
    {
        private bool _shouldTerminateTimer;

		public SuperHeroesPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            RemoveAllEffects();

            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                ToggleEffect();
                return !_shouldTerminateTimer;
            });

            MessagingCenter.Subscribe<object>(this, "AddHero", OnSuperHeroAdded);
        }

        protected override void OnDisappearing()
        {
            _shouldTerminateTimer = true;
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
            await Clipboard.SetTextAsync("https://comicvine.gamespot.com/profile/lvenger/lists/my-100-favourite-superheroes/17520/");
            await DisplayAlert("Link copied", "Superheroes link copied to clipboard", "OK");
        }

        private void Toggle_Filter(object sender, EventArgs e)
        {
            ToggleEffect();
        }

        private void ToggleEffect()
        {
            var filterEffect = KpnImage.Effects.FirstOrDefault();
            if (filterEffect != null)
            {
                KpnImage.Effects.Remove(filterEffect);
            }
            else
            {
                KpnImage.Effects.Add(new ImageFilterEffect());
            }
        }

        private void RemoveAllEffects()
        {
            KpnImage.Effects.Clear();
        }
    }
}