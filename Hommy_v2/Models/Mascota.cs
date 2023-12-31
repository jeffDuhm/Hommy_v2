﻿using SQLite;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hommy_v2.Models
{
    public class Mascota
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public byte[] Foto { get; set; } // Ruta de la foto de la mascota
        public string Nombre { get; set; }
        public string Raza {  get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Especie { get; set; }
        public string Tamannio { get; set; }
        public string Descripcion { get; set; }

    }

}
