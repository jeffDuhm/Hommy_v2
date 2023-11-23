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
    public partial class AdopcionesPage : ContentPage
    {
        public AdopcionesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarSolicitudes();

        }

        private async void CargarSolicitudes()
        {
            var solicitudes = await App.Context.ObtenerSolicitud();
            listaSolicitudes.ItemsSource = solicitudes;

        }

        private async void VerAdopcionClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Solicitud solicitud)
            {
                await Navigation.PushAsync(new DetalleAdopcionesPage(solicitud));
            }
        }
    }
}