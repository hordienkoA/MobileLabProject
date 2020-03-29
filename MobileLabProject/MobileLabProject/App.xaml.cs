using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileLabProject
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "words.db";
        public static WordsRepository database;
        public static WordsRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new WordsRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));

                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
