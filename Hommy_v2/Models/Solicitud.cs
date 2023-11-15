using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Hommy_v2.Models
{
    public class Solicitud
    {
        [PrimaryKey, AutoIncrement]
        public int SolicitudID { get; set; }

        public string NombreMascota { get; set; }

        public string Estado {  get; set; }
        public string Solicitante { get; set; }

        public string Direccion { get; set; }

        public string Celular {  get; set; }

        public string Correo { get; set; }

        public string Edad { get; set; }

        public DateTime FechaSolicitud { get; set; }
    }
}
