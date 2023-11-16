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
    public partial class BienvenidaUsuarioPage : ContentPage
    {
        public BienvenidaUsuarioPage()
        {
            InitializeComponent();
        }

        private void ElegirRolClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RolUsuarioPage(); // Me permite ir a otra page
        }
    }
}