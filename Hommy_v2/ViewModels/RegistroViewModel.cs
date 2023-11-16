using Hommy_v2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Hommy_v2.Models;

namespace Hommy_v2.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        //Atributos
        public string correo;
        public string contrasennia;
        public string rol;
        public string nombre;
        public string confirmarcontrasennia;

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        // Propiedades de datos personales
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string ConfirmarContrasennia
        {
            get { return confirmarcontrasennia; }
            set { confirmarcontrasennia = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public string Contrasennia
        {
            get { return contrasennia; }
            set { contrasennia = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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


        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Registrarse);
            }
        }

        //Methods

        private async void Registrarse()
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
            else if (string.IsNullOrEmpty(contrasennia))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un contraseña",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un nombre",
                    "Aceptar");
                return;
            }

            if(contrasennia != confirmarcontrasennia)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Las contraseñas no coinciden",
                    "Aceptar");
                return;
            }
            if (rol == null)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes seleccionar un rol",
                    "Aceptar");
                return;
            }

            IsVisibleTxt = true;
            IsRunningTxt = true;
            IsEnabledTxt = false;


            await Task.Delay(1000); // Retraso

            // Usuario
            var usuario = new Usuario
            {
                Correo = correo,
                Contrasennia = contrasennia,
                Nombre = nombre,
                ConfirmarContrasennia = confirmarcontrasennia,
                CreacionFecha = DateTime.Now,
                Rol = rol,

            };

            await App.Context.GuardarUsuarioAsync(usuario);

            await Application.Current.MainPage.DisplayAlert("Exitoso", "Bienvenido " + nombre.ToString() + " a Hommy", "Ok");

            IsRunningTxt = false;
            IsVisibleTxt = false;
            IsEnabledTxt = true;

            // Navega al LoginPage

            Application.Current.MainPage = new LoginPage();

        }

        //COnstructor
        public RegistroViewModel()
        {
            IsEnabledTxt = true;
        }
    }
}
