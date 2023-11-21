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
    public partial class InicioUsuarioPage : ContentPage
    {
        public InicioUsuarioPage()
        {
            InitializeComponent();
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {

        }

        private async void IrMascotasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MascotasUsuariosPage());
        }
    }
}