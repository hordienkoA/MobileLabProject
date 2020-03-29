using MobileLabProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileLabProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordsListPage : ContentPage
    {
        public WordsListPage()
        {
            InitializeComponent();
            BindingContext = new WordListViewModel() { Navigation=this.Navigation};
        }
    }
}