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
    public partial class DetalleSolicitudUsuarioPage : ContentPage
    {
        public DetalleSolicitudUsuarioPage(Solicitud solicitud)
        {
            InitializeComponent();
            BindingContext = new DetallesSolicitudViewModel(solicitud);
        }
    }
}