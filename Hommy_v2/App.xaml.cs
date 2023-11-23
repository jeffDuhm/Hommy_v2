using Hommy_v2.Data;
using Hommy_v2.Models;
using Hommy_v2.Services;
using Hommy_v2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2
{
    public partial class App : Application
    {
        public static  Usuario UsuarioActual { get; set; }
        public static DataBaseContext Context { get; set; }

        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new SplashScreenHommy());

            
        }

        private void InitializeDatabase()
        {
            // Accediendo a la bd
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Hommy.db3");
            Context = new DataBaseContext(dbPath);

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
