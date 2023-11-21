using Hommy_v2.Models;
using Hommy_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views.MasterUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuUsuarioFlyout : ContentPage
    {
        public ListView ListView;

        public MenuUsuarioFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuUsuarioFlyoutViewModel();
       
            ListView = MenuItemsListView;
        }

        private class MenuUsuarioFlyoutViewModel : INotifyPropertyChanged
        {

            public ObservableCollection<MenuUsuarioFlyoutMenuItem> MenuItems { get; set; }

            public MenuUsuarioFlyoutViewModel()
            {
                
               

              MenuItems = new ObservableCollection<MenuUsuarioFlyoutMenuItem>(new[]
                {
                    new MenuUsuarioFlyoutMenuItem { Id = 0, Title = "Inicio", TargetType = typeof(InicioUsuarioPage), Icon = "inicio.png"},
                    new MenuUsuarioFlyoutMenuItem { Id = 1, Title = "Mascotas", TargetType = typeof(MascotasUsuariosPage), Icon = "mascotas.png" },
                    new MenuUsuarioFlyoutMenuItem { Id = 2, Title = "Solicitudes", Icon = "solicitudes.png"},
                    new MenuUsuarioFlyoutMenuItem { Id = 3, Title = "Mis donaciones", Icon = "donaciones.png" },
                    new MenuUsuarioFlyoutMenuItem { Id = 4, Title = "Mensajería", TargetType = typeof(ChatbotPage), Icon = "chatbot.png"},
                   
                });
            }



            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void CerrarSesionClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}