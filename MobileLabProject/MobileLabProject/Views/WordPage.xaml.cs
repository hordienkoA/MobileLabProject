using MobileLabProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileLabProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordPage : ContentPage
    {
        public WordViewModel ViewModel { get; private set; }
        public WordPage(WordViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;

        }

        private async void SpeakRuBtn_Clicked(object sender, EventArgs e)
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            var settings = new SpeechOptions { Locale = locales.FirstOrDefault(l => l.Country == "RU") };
            await TextToSpeech.SpeakAsync(RussianWord.Text, settings);
        }
            
                
          
        private async void SpeakEnglishBtn_Clicked(object sender, EventArgs e)
        {


            var locales = await TextToSpeech.GetLocalesAsync();

            var settings = new SpeechOptions { Locale = locales.FirstOrDefault(l => l.Country == "US") };

            await TextToSpeech.SpeakAsync(EnglishWord.Text,settings);
        }
    }
}