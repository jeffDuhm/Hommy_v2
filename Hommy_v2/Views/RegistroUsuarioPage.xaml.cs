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
    public partial class RegistroUsuarioPage : ContentPage
    {
        public RegistroUsuarioPage()
        {
            InitializeComponent();
            BindingContext = new RegistroViewModel();
        }

        private void IrLoginClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage(); // Me permite ir a otra page
        }
    }
}