using MobileLabProject.Models;
using MobileLabProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileLabProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainWords : ContentPage
    {
        ObservableCollection<Word> collection;
        ObservableCollection<Word> Sessioncollection;
        int points = 0;
        bool isEnglish = false;
        public TrainWords()
        {
            InitializeComponent();
            
            collection = new ObservableCollection<Word>(App.Database.GetWords());
            Sessioncollection = new ObservableCollection<Word>(App.Database.GetWords());
            ActualField.Text = isEnglish==false?Sessioncollection[0].RussianWord:Sessioncollection[0].EnglishWord;
            
            
        }

        

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            points = 0;
            collection = new ObservableCollection<Word>(App.Database.GetWords());
            Sessioncollection = new ObservableCollection<Word>(App.Database.GetWords());

            ActualField.Text = isEnglish == false ? Sessioncollection[0].RussianWord : Sessioncollection[0].EnglishWord;
            answerFld.Text = "";
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += async (s, ev) =>
            {
                var locales = await TextToSpeech.GetLocalesAsync();
                SpeechOptions so;
                if (isEnglish)
                {
                    so = new SpeechOptions { Locale = locales.FirstOrDefault(l => l.Country == "US") };
                }
                else
                {
                    so = new SpeechOptions { Locale = locales.FirstOrDefault(l => l.Country == "RU") };
                }
                await TextToSpeech.SpeakAsync(ActualField.Text, so);
            };
            ActualField.GestureRecognizers.Add(tgr);
        }

        private void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            var currentWord = collection.FirstOrDefault(w => (isEnglish == false ? w.RussianWord : w.EnglishWord) == ActualField.Text);
            if ((isEnglish==false?currentWord.EnglishWord:currentWord.RussianWord) == answerFld.Text.Trim())
            {
                points++;
                

            }
            Sessioncollection.RemoveAt(0);
            ActualField.Text = Sessioncollection.Count() == 0 ? $"{points}/{collection.Count()}" : isEnglish == false ? Sessioncollection[0].RussianWord : Sessioncollection[0].EnglishWord;

        }

        private void SwitchBtn_Clicked(object sender, EventArgs e)
        {
            ResetBtn_Clicked(this, null);
            isEnglish = !isEnglish;
            collection = new ObservableCollection<Word>(App.Database.GetWords());
            Sessioncollection = new ObservableCollection<Word>(App.Database.GetWords());
            ActualField.Text = isEnglish == false ? Sessioncollection[0].RussianWord : Sessioncollection[0].EnglishWord;
        }
    }
}