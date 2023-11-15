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
    public partial class PerfilMascotaPage : ContentPage
    {
        public PerfilMascotaPage(Mascota mascota)
        {
            InitializeComponent();
            BindingContext = mascota;
            
        }

        private async void AdoptarMascotaClicked(object sender, EventArgs e)
        {

            if (sender is Button button && button.BindingContext is Mascota mascota)
            {
                var registroSolicitudViewModel = new RegistroSolicitudViewModel(mascota);
                var registroSolicitudPage = new RegistroSolicitudPage(registroSolicitudViewModel);
                await Navigation.PushAsync(registroSolicitudPage);
            }

            ////Crear la página de registro de solicitud y pasar la información de la mascota
            //if (sender is Button button && button.BindingContext is Mascota mascota)
            //{
            //    await Navigation.PushAsync(new RegistroSolicitudPage(mascota));
            //}
            //await Navigation.PushAsync(new RegistroSolicitudPage());

        }
    }
}