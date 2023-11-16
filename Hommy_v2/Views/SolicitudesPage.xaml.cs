using Hommy_v2.Models;
using Hommy_v2.ViewModels;
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
    public partial class SolicitudesPage : ContentPage
    {
        public SolicitudesPage()
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

        private async void BtnEliminarSolicitudClicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "¿Está seguro de eliminar el elemento?", "Sí", "No"))
            {
                var solicitud = (Solicitud)(sender as MenuItem).CommandParameter;
                var result = await App.Context.EliminarSolicitudAsync(solicitud);
                if (result == 1)
                {
                    CargarSolicitudes();
                }
            }
        }

        private async void VerSolicitudClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Solicitud solicitud)
            {
                await Navigation.PushAsync(new DetalleSolicitudPage(solicitud));
            }
            //if (sender is Button button && button.BindingContext is Solicitud solicitud)
            //{
            //    var registroSolicitudViewModel = new RegistroSolicitudViewModel(solicitud);
            //    var detalleSolicitudPage = new DetalleSolicitudPage(registroSolicitudViewModel);
            //    await Navigation.PushAsync(detalleSolicitudPage);
            //}

        }
    }
}