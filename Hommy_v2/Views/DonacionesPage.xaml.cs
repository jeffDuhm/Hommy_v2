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
    public partial class DonacionesPage : ContentPage
    {
        public DonacionesPage()
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


        private void OnSearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void MascotasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void BtnEliminarMascotaClicked(object sender, EventArgs e)
        {

        }

        private async  void VerSolicitudClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Solicitud solicitud)
            {
                await Navigation.PushAsync(new DetalleSolicitudPage(solicitud));
            }
        }
    }
}