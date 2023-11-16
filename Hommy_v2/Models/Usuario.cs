using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Hommy_v2.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public string Contrasennia { get; set; }
        public string ConfirmarContrasennia { get; set; }

        public DateTime CreacionFecha { get; set; }
    }
}
