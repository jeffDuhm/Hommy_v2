using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Hommy_v2.Data;
using SQLite;
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
        // Agrega otras propiedades según sea necesario


        //public void SetImageSource(ImageSource imageSource)
        //{
        //    Foto = DataBaseContext.ImageToBytes(imageSource);
        //}
        public void SetImageSource(ImageSource imageSource)
        {
            if (imageSource is StreamImageSource streamImageSource)
            {
                System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                Task<Stream> task = streamImageSource.Stream(cancellationToken);
                Stream stream = task.Result;
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    Foto = ms.ToArray();
                }
            }
        }

        public ImageSource GetImageSource()
        {
            if (Foto != null)
            {
                return ImageSource.FromStream(() => new MemoryStream(Foto));
            }
            return null;
        }

    }

}
