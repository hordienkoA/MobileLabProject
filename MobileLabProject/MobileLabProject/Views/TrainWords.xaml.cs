using MobileLabProject.Models;
using MobileLabProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public TrainWords()
        {
            InitializeComponent();
            
            collection = new ObservableCollection<Word>(App.Database.GetWords());
            Sessioncollection = new ObservableCollection<Word>(App.Database.GetWords());
            ActualField.Text = Sessioncollection[0].RussianWord;
            
            
        }

        

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            var currentWord = collection.FirstOrDefault(w => w.RussianWord == ActualField.Text);
            if (currentWord.EnglishWord == answerFld.Text.Trim())
            {
                points++;
                

            }
            Sessioncollection.Remove(currentWord);
            ActualField.Text = Sessioncollection.Count() == 0 ? $"{points}/{collection.Count()}" : Sessioncollection[0].RussianWord;

        }
    }
}