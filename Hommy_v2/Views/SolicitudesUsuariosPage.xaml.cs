using Hommy_v2.Models;
using Hommy_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolicitudesUsuariosPage : ContentPage
    {
        public SolicitudesUsuariosPage()
        {
            InitializeComponent();
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarSolicitudesUsuarios();


        }


        private async void CargarSolicitudesUsuarios()

        {
            Usuario usuarioActual = new Usuario();

            if (usuarioActual != null)
            {
                int usuarioId = usuarioActual.UsuarioID;
                var solicitudes = await App.Context.ObtenerSolicitudPorUsuarioIdAsync(usuarioId);

                // Mostrar las solicitudes filtradas al usuario
                listaSolicitudes.ItemsSource = solicitudes;
            }

            //Usuario usuarioActual = App.UsuarioActual;

            //if (usuarioActual != null)
            //{
            //    // Cambiado a obtener el usuario por correo electrónico
            //    Usuario usuario = await App.Context.ObtenerUsuarioPorCorreoAsync(usuarioActual.Correo);

            //    if (usuario != null)
            //    {
            //        int usuarioId = usuario.UsuarioID;
            //        var solicitudes = await App.Context.ObtenerSolicitudPorUsuarioIdAsync(usuarioId);

            //        // Mostrar las solicitudes filtradas al usuario
            //        listaSolicitudes.ItemsSource = solicitudes;
            //    }
            //}

        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void BtnEliminarSolicitudClicked(object sender, EventArgs e)
        {

        }

        private async void VerSolicitudClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Solicitud solicitud)
            {
                await Navigation.PushAsync(new DetalleSolicitudUsuarioPage(solicitud));
            }
        }
    }
}