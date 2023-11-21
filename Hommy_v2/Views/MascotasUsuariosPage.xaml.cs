using Hommy_v2.Models;
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
    public partial class MascotasUsuariosPage : ContentPage
    {
        public MascotasUsuariosPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
       
            CargarMascotas();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

        private async void CargarMascotas()
        {
            var mascotas = await App.Context.ObtenerTodasLasMascotasAsync();
            listaMascotas.ItemsSource = mascotas;

        }

        private async void VerPerfilMascota(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Mascota mascota)
            {
                await Navigation.PushAsync(new PerfilMascotaPage(mascota));
            }
        }
    }
}