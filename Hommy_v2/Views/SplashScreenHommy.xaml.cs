using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreenHommy : ContentPage
    {
        public SplashScreenHommy()
        {
            InitializeComponent();
            Animacion();
        }


        public async Task Animacion() //Async -> Ejecuta procesos en segundo plano (a la vez)
        {
            imgLogo.Opacity = 0; // Modo transparente
            await imgLogo.FadeTo(1, 3000); // Milisegundos
            Application.Current.MainPage = new BienvenidaUsuarioPage(); // Me permite ir a otra page


        }
    }
}