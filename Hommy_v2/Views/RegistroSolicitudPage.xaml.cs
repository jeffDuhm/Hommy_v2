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
    public partial class RegistroSolicitudPage : ContentPage
    {
        public RegistroSolicitudPage(RegistroSolicitudViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
       
        }

        private void EnviarSolicitudClicked(object sender, EventArgs e)
        {
            
        }
    }
}