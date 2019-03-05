using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinBootcamp.ViewModels
{
    public class SuperHeroesPageViewModel: ViewModelBase
    {
        private ObservableCollection<SuperHeroesViewModel> _superHeroes = new ObservableCollection<SuperHeroesViewModel>();
        private string _addHeroName;
        private string _addHeroImagePreview;
        private string _addHeroDescription;

        public string AddHeroName
        {
            get => _addHeroName;
            set
            {
                if (_addHeroName == value)
                {
                    return;
                }

                _addHeroName = value;
                OnPropertyChanged(nameof(AddHeroName));
            }
        }

        public string AddHeroImagePreview
        {
            get => _addHeroImagePreview;
            set
            {
                if (_addHeroImagePreview == value)
                {
                    return;
                }

                _addHeroImagePreview = value;
                OnPropertyChanged(nameof(AddHeroImagePreview));
            }
        }

        public string AddHeroDescription
        {
            get => _addHeroDescription;
            set
            {
                if (_addHeroDescription == value)
                {
                    return;
                }

                _addHeroDescription = value;
                OnPropertyChanged(nameof(AddHeroDescription));
            }
        }

        public ObservableCollection<SuperHeroesViewModel> SuperHeroes
        {
            get => _superHeroes;
            set
            {
                if (_superHeroes == value)
                {
                    return;
                }

                _superHeroes = value;
                OnPropertyChanged(nameof(SuperHeroesViewModel));
            }
        }

        public ICommand AddHeroCommand { get; set; }

        public SuperHeroesPageViewModel()
        {
            SuperHeroes.Add(SuperHeroesViewModel.Create(
                "Superman", 
                "My all time favourite superhero, comic book and fictional character. He became my favourite through a mixture of the Disney Hercules film, the Superman cartoons and the Black Lace song Superman. Being British, Superman isn't an American icon to me. Instead he represents the best attributes of humanity and the ultimate force for good imaginable. Superman represents us at our absolute best. He's an ideal of humanity's values and morals but he is relatable enough to still be considered a meaningful character, not a distant icon. The irony behind Superman for me is that despite being an alien with godlike powers, he acts as human as the rest of us due to his upbringing from The Kents. His selflessness, compassion and the desire to always do the right thing are traits we could learn from and aspire to. Superman's been used in my upbringing as a moral authority and remains to me the superhero archetype by which all other heroes are measured. I'm almost certain there'll never be a comic book or fictional character I'll love more than Superman. He is simply the greatest fictional character to me.", 
                new Uri("https://static.comicvine.com/uploads/scale_small/13/132327/6507037-28872490_1638064799604695_1250122498385004714_n.jpg")));

            SuperHeroes.Add(SuperHeroesViewModel.Create(
                "Batman",
                "Currently the coolest superhero around, I did watch the immensely successful 1990s Batman cartoon but the Batman Beyond cartoon is what got me interested in Batman. Obviously, Bruce Wayne is my favourite now. His obsessive crusade against the endless wave of crime in Gotham City has made him an endearing character and Batman's gritted determination to carry on his war on crime against all the odds make him an utterly awesome character which makes his stories all the more legendary. Batman is an example that if we set our minds to something, we can do or be anything we choose to be. Not to mention his inherent contradictions deepen the character even more. His logical demeanour is countered by his flair for the theatrical, his vigilante status contrasted by his presence as the protector of Gotham and his ultimate loner figure alongside a family of fellow heroes. And despite Batman waging a ruthless war against criminals, he holds himself in check with a strong moral code. These dichotomies are what make Batman a complex and deep character for me.", 
                new Uri("https://static.comicvine.com/uploads/scale_small/11125/111253436/6733777-4.jpg")));

            SuperHeroes.Add(SuperHeroesViewModel.Create(
                "Spider-man",
                "Watching the 1996 Spider-Man cartoon and finding Spidey's wisecracks very amusing plus owning several classic Spider-Man comics, this guy is my 3rd favourite superhero. After all, Peter Parker is the most relatable superhero around. Throughout his 50 year tenure, Peter has faced at least one problem which most readers can relate to in some degree. Throughout his history, there's probably been at least one problem readers and fans can relate with. And despite all the tragedy in his life, Spider-Man picks himself up and carries on fighting thanks to those immortal wise words: \"With Great Power comes Great Responsibility.\" Even though he may make mistakes and screw up, Spider-Man continues to do good in spite of the adversity he has suffered from. And that's what makes him the iconic everyman superhero we can all relate to in some way. Although Spider-Man is my third favourite superhero, his post One More Day status quo has been generally awful for the character's progression and growth. So I should clarify that Pre 2006/OMD Spider-Man is my third favourite superhero.", 
                new Uri("https://static.comicvine.com/uploads/scale_small/8/80103/6197311-c6d76a022f2dcf57c29e2ef87a3c7d47.jpg")));

            SuperHeroes.Add(SuperHeroesViewModel.Create(
                "Hal Jordan",
                "Originally my favourite Green Lantern was John Stewart and I knew more about Kyle Rayner than Hal Jordan but since hearing the hype about the Sinestro Corps War, I read Blackest Night and started collecting the Geoff Johns Green Lantern series. This showed me what a brilliant character Hal is. His determination, cockiness and ability to continue moving forward in spite of his past made for a compelling character arc in my eyes. As such, Hal is now my favourite Green Lantern of them all.", 
                new Uri("https://static.comicvine.com/uploads/scale_small/11114/111147698/6520709-1532011657748.jpg")));

            SuperHeroes.Add(SuperHeroesViewModel.Create(
                "Thor",
                "His place here is down to JMS' run on the Thor series. JMS gave me a new look at Thor's character, namely giving him epic fantasy, engrossing adventures whilst also humanising the God of Thunder. This lead me to read more into the world of Thor. His place in mythology interested me further as I have always had a soft spot for ancient myths and legends. Thor's nobility, honour and humility make for excellent characteristics for the stoic hero he is. Thor serves as the link between the ancient mythologies throughout human history that created supernatural beings to worship and current comic book superheroes that have become the new modern day myths. This is what makes Thor an engrossing character in a literal god serving as a hero and protector of mankind.", 
                new Uri("https://static.comicvine.com/uploads/scale_small/10/100647/6436253-thor2.jpg")));


            AddHeroCommand = new Command(AddHero);
        }

        private void AddHero()
        {
            if (!Uri.TryCreate(AddHeroImagePreview, UriKind.Absolute, out Uri imagePreview))
            {
                imagePreview = new Uri("http://www.wordunknown.com/img/wordunknown.png");
            }
            SuperHeroes.Add(SuperHeroesViewModel.Create(AddHeroName, AddHeroDescription, imagePreview));

            AddHeroName = string.Empty;
            AddHeroImagePreview = string.Empty;
            AddHeroDescription = string.Empty;

            MessagingCenter.Send<object>(this, "AddHero");
        }
    }

    public class SuperHeroesViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri PreviewImage { get; set; }

        private SuperHeroesViewModel() {    }

        public static SuperHeroesViewModel Create(string name, string description, Uri previewImage)
        {
            return new SuperHeroesViewModel
            {
                Name = name,
                Description = description,
                PreviewImage = previewImage
            };
        }
    }
}