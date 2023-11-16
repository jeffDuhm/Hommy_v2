using Hommy_v2.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using Hommy_v2.Models;
using System.Diagnostics;

namespace Hommy_v2.ViewModels
{
    public class RegistroSolicitudViewModel : BaseViewModel
    {
        //Atributos
        public string solicitante;
        public string estado;
        public string direccion;
        public string celular;
        public string correo;
        public string edad;

        public Mascota MascotaSeleccionada { get; set; }

        

        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;

        // Propiedades de datos personales

        public string SolicitanteTxt
        {
            get { return solicitante; }
            set { solicitante = value; }
        }

        public string DireccionTxt
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string CelularTxt
        {
            get { return celular; }
            set { celular = value; }
        }

        public string CorreoTxt
        {
            get { return correo; }
            set { correo = value; }
        }

        public string EdadTxt
        {
            get { return edad; }
            set { edad = value; }
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
                return new RelayCommand(RegistrarSolicitud);
            }
        }

        //Methods

        private async void RegistrarSolicitud()
        {
            //Validaciones
            if (string.IsNullOrEmpty(solicitante))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un nombre",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(direccion))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una dirección ",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un correo",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(celular))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un correo",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(edad))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar un correo",
                    "Aceptar");
                return;
            }

            IsVisibleTxt = true;
            IsRunningTxt = true;
            IsEnabledTxt = false;


            await Task.Delay(1000); // Retraso

            // Solicitud
            var solicitud = new Solicitud
            {
                NombreMascota = MascotaSeleccionada.Nombre,
                Estado = "Pendiente",
                Solicitante = solicitante,
                Direccion = direccion,
                Celular = celular,
                Correo = correo,
                Edad = edad,
                FechaSolicitud = DateTime.Now,

            };

            await App.Context.GuardarSolicitudAsync(solicitud);
            await Application.Current.MainPage.DisplayAlert("Éxito", "Solicitud enviada", "Aceptar");


            IsRunningTxt = false;
            IsVisibleTxt = false;
            IsEnabledTxt = true;

            await Application.Current.MainPage.Navigation.PopAsync();

        }
        

        //private readonly Solicitud solicitud;  // La solicitud actual mostrada en la página

        //// Comandos
        //public ICommand AprobarCommand { get; }
        //public ICommand RechazarCommand { get; }



        //private void AprobarSolicitud()
        //{
        //    // Lógica para aprobar la solicitud
        //    CambiarEstado("Aprobado");
        //    ActualizarListaSolicitudes();
        //    // Actualizar el estado de la solicitud y notificar cambios

        //}

        //private void RechazarSolicitud()
        //{
        //    // Lógica para rechazar la solicitud
        //    CambiarEstado("Rechazado");
        //    ActualizarListaSolicitudes();

        //    // Actualizar el estado de la solicitud y notificar cambios
        //}


        //private async void ActualizarListaSolicitudes()
        //{

        //    // Actualizar la lista de solicitudes y notificar cambios

        //    await App.Context.ActualizarSolicitudAsync(solicitud);
        //}

        //// Método para cambiar el estado de la solicitud
        //private async void CambiarEstado(string nuevoEstado)
        //{
        //    solicitud.Estado = nuevoEstado;

        //    // Lógica adicional si es necesario, como guardar en la base de datos
        //    await App.Context.ActualizarEstadoSolicitudAsync(solicitud.SolicitudID, nuevoEstado);
        //}



        //Constructor
        public RegistroSolicitudViewModel(Mascota mascotaSeleccionada)
        {
            MascotaSeleccionada = mascotaSeleccionada;
            IsEnabledTxt = true;
        }

        public RegistroSolicitudViewModel()
        {
            IsEnabledTxt = true;
        }

        //public RegistroSolicitudViewModel(Solicitud solicitud)
        //{
        //    this.solicitud = solicitud;
        //    AprobarCommand = new Command(AprobarSolicitud);
        //    RechazarCommand = new Command(RechazarSolicitud);
        //    IsEnabledTxt = true;
        //}



    }

    
}
