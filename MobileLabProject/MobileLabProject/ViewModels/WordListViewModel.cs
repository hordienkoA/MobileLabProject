using MobileLabProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileLabProject.ViewModels
{
    public class WordListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WordViewModel> Words { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateWordCommand { protected set; get; }
        public ICommand DeleteWordCommand { protected set; get; }
        public ICommand SaveWordCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public ICommand SpeakCommand { protected set; get; }
        WordViewModel selectedWord;

        public INavigation Navigation { get; set; }

        public WordListViewModel()
        {
            Words = new ObservableCollection<WordViewModel>();
            foreach(var v in App.Database.GetWords())
            {
                Words.Add(new WordViewModel() { RussianWord = v.RussianWord, EnglishWord = v.EnglishWord,Id=v.Id });
            }
            CreateWordCommand = new Command(CreateWord);
            DeleteWordCommand = new Command(DeleteWord);
            SaveWordCommand = new Command(SaveWord);
            BackCommand = new Command(Back);
            
        }

        

        public WordViewModel SelectedWord
        {
            get { return selectedWord; }
            set
            {
                if (selectedWord != value)
                {
                    WordViewModel tempWord = value;
                    selectedWord = null;
                    OnProperyChanged("SelectedWord");
                    Application.Current.MainPage.Navigation.PushAsync(new WordPage(tempWord));
                }
            }
        }

        private void OnProperyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private void SaveWord(object obj)
        {
            WordViewModel word = obj as WordViewModel;
            if (Words != null && word.IsValid)
            {
                Words.Add(word);
                App.Database.SaveWord(word.Word);
            }
            Back();
        }

        private void DeleteWord(object obj)
        {
            WordViewModel word = obj as WordViewModel;
            if (word != null)
            {
                Words.Remove(word);
                App.Database.DeleteWord(word.Id);
            }
            Back();
        }

        private void CreateWord(object obj)
        {
            Navigation.PushAsync(new WordPage(new WordViewModel() { ListViewModel = this }) {Title="Добавление слова" });
        }
    }
}
