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
    public partial class RolUsuarioPage : ContentPage
    {
        public RolUsuarioPage()
        {
            InitializeComponent();
        }

        private void IrRefugioClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistroUsuarioPage(); // Me permite ir a otra page
        }

        private void IrUsuarioClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegistroUsuarioPage(); // Me permite ir a otra page
        }
    }
}