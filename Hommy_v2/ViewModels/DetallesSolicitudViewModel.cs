using Hommy_v2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hommy_v2.ViewModels
{
    public class DetallesSolicitudViewModel : BaseViewModel
    {
        
        private readonly Solicitud solicitud;  // La solicitud actual mostrada en la página
        public string NombreSolicitante => solicitud.Solicitante;
        public string NombreMascota => solicitud.NombreMascota;
        public string Estado => solicitud.Estado;
        public DateTime FechaSolicitud => solicitud.FechaSolicitud;
        public string Direccion => solicitud.Direccion;
        public string Celular => solicitud.Celular;
        public string Correo => solicitud.Correo;
        public string Edad => solicitud.Edad;
        


        // Constructor que recibe la solicitud
        public DetallesSolicitudViewModel(Solicitud solicitud)
        {
            this.solicitud = solicitud;
            AprobarCommand = new Command(AprobarSolicitud);
            RechazarCommand = new Command(RechazarSolicitud);
        }

        public DetallesSolicitudViewModel()
        {
        }

        // Comandos
        public ICommand AprobarCommand { get; }
        public ICommand RechazarCommand { get; }


        private async void AprobarSolicitud()
        {
            // Lógica para aprobar la solicitud
            CambiarEstado("Aprobado");
            // Actualizar el estado de la solicitud y notificar cambios
            ActualizarListaSolicitudes();
            await Application.Current.MainPage.Navigation.PopAsync();

        }

        private async void RechazarSolicitud()
        {
            // Lógica para rechazar la solicitud
            CambiarEstado("Rechazado");
            ActualizarListaSolicitudes();
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        private async void ActualizarListaSolicitudes()
        {

            // Actualizar la lista de solicitudes y notificar cambios

            await App.Context.ActualizarSolicitudAsync(solicitud);
        }

        // Método para cambiar el estado de la solicitud
        private async void CambiarEstado(string nuevoEstado)
        {
            solicitud.Estado = nuevoEstado;

            // Lógica adicional si es necesario, como guardar en la base de datos
            await App.Context.ActualizarEstadoSolicitudAsync(solicitud.SolicitudID, nuevoEstado);
        }

    }
}
