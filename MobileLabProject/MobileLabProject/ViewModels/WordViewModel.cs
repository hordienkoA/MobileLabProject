using MobileLabProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileLabProject.ViewModels
{
    public class WordViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        WordListViewModel lvm;

        public Word Word { get; private set; }

        public WordViewModel()
        {
            Word = new Word();
        }

        public WordListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnProperyChange("ListViewModel");
                }
            }
        }

        public int Id
        {
            get { return Word.Id; }
            set
            {
                if (Word.Id != value)
                {
                    Word.Id = value;
                    OnProperyChange("Id");
                }
            }
        }
        public string RussianWord
        {
            get { return Word.RussianWord; }
            set
            {
                if (Word.RussianWord != value)
                {
                    Word.RussianWord = value;
                    OnProperyChange("RussianWord");
                }
            }
        }

        public string EnglishWord
        {
            get { return Word.EnglishWord; }
            set
            {
                if (Word.EnglishWord != value)
                {
                    Word.EnglishWord = value;
                    OnProperyChange("EnglishWord");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(RussianWord.Trim()) ||
                    !string.IsNullOrEmpty(EnglishWord.Trim())));
            }
        }
        private void OnProperyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
