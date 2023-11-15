using Hommy_v2.Models;
using Hommy_v2.Services;
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
    public partial class DetalleSolicitudPage : ContentPage
    {
        public DetalleSolicitudPage(Solicitud solicitud)
        {
            InitializeComponent();
            BindingContext = new DetallesSolicitudViewModel(solicitud);

        }

        private async void AprobarSolicitudClicked(object sender, EventArgs e)
        {
           

        }

        private void RechazarSolicitudClicked(object sender, EventArgs e)
        {
            

        }



    }
}