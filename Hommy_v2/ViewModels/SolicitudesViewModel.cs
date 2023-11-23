using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hommy_v2.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Security.Cryptography;
using Xamarin.Essentials;
using Xamarin.Forms.PlatformConfiguration;

namespace Hommy_v2.ViewModels
{
    public class SolicitudesViewModel : BaseViewModel
    {
        public ICommand ExportarCSVCommand => new Command(async () => await ExportarCSVAsync());

        public async Task ExportarCSVAsync()
        {
            
            List<Solicitud> listaSolicitudes = await App.Context.ObtenerSolicitud(); // Asegúrate de tener un método para obtener la lista

            // Generar el contenido CSV
            string contenidoCSV =  GenerarContenidoCSV(listaSolicitudes);

            // Guardar el archivo CSV en el almacenamiento local
            string filePath = await GuardarCSVLocalAsync(contenidoCSV);

            // Mostrar mensaje de éxito o manejar según necesidad
            await Application.Current.MainPage.DisplayAlert("Éxito", $"El archivo CSV se guardó en {filePath}", "Aceptar");

      

        }

        private string GenerarContenidoCSV(List<Solicitud> listaSolicitudes)
        {
            StringBuilder csvContent = new StringBuilder();

            // Agregar encabezados (nombres de las columnas)
            csvContent.AppendLine("NombreMascota,Estado,Solicitante,Direccion,Celular,Correo,Edad,FechaSolicitud");

            // Agregar datos de cada solicitud
            foreach (var solicitud in listaSolicitudes)
            {
                csvContent.AppendLine($"{solicitud.NombreMascota},{solicitud.Estado},{solicitud.Solicitante},{solicitud.Direccion},{solicitud.Celular},{solicitud.Correo},{solicitud.Edad},{solicitud.FechaSolicitud}");
            }

            return csvContent.ToString();
        }

        private async Task<string> GuardarCSVLocalAsync(string contenidoCSV)
        {
            // Obtener el directorio de documentos del sistema
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            // Crear el nombre del archivo CSV
            string fileName = "solicitudes.csv";

            // Combinar el directorio y el nombre del archivo para obtener la ruta completa
            string filePath = Path.Combine(documentsPath, fileName);

            // Escribir el contenido CSV en el archivo
            File.WriteAllText(filePath, contenidoCSV);

            return filePath;
        }




    }
}
