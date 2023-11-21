using Hommy_v2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using Hommy_v2.Models;
using System.Linq;
using Hommy_v2.Views.MasterUsuario;

namespace Hommy_v2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //Atributos
        public string correo;
        public string contrasennia;
        
        public string nombre;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        // Propiedades de datos personales
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Contrasennia
        {
            get { return contrasennia; }
            set { contrasennia = value; }
        }


        // Propiedades para el estado de la vista
        public bool IsRunningTxt
        {
            get { return isRunning; }
            set { isRunning = value; }
        }

        public bool IsVisibleTxt
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public bool IsEnabledTxt
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }

        // Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(IniciarSesion);
            }
        }

        //Methods

        public async void IniciarSesion()
        {
            //Validaciones
            if (string.IsNullOrEmpty(correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un correo",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(contrasennia))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un contraseña",
                    "Aceptar");
                return;
            }

            IsVisibleTxt = true;
            IsRunningTxt = true;
            IsEnabledTxt = false;

            await Task.Delay(20); // Retraso

            List<Usuario> e = App.Context.ValidarUsuarios(correo, contrasennia).Result;

            if (e.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Correo o Contraseña incorrecta",
                "Aceptar");

                IsVisibleTxt = false;
                IsRunningTxt = false;
                IsEnabledTxt = true;
            }


            //else if (e.Count > 0)
            //{
            //    Application.Current.MainPage = new AppShell();

            //    IsVisibleTxt = false;
            //    IsRunningTxt = false;
            //    IsEnabledTxt = true;
            //}

            // Verificar las credenciales del usuario
            var usuario = await App.Context.ValidarUsuarios(correo, contrasennia);

            if (usuario != null && usuario.Any())
            {
                var primerUsuario = usuario.First(); // Tomar el primer usuario de la lista
                string rol = primerUsuario.Rol;

                // Realizar acciones adicionales según el rol
                ProcesarSegunRol(rol);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Credenciales inválidas", "Aceptar");
            }


        }

        private void ProcesarSegunRol(string rol)
        {
            // Aquí puedes realizar acciones adicionales según el rol
            switch (rol)
            {
                case "Propietario":
                    // Navegar a la interfaz del propietario
                    Application.Current.MainPage = new AppShell();
                    break;
                case "Usuario":
                    // Navegar a la interfaz del usuario
                    Application.Current.MainPage = new MenuUsuario();
                    break;
            }
        }

        public LoginViewModel()
        {
            IsEnabledTxt = true;
        }
    }
}
