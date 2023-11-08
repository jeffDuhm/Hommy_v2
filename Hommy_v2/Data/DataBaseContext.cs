using Hommy_v2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hommy_v2.Data
{
    public class DataBaseContext
    {
        public SQLiteAsyncConnection Connection { get; set; }

        public DataBaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);
            Connection.CreateTableAsync<Mascota>().Wait();
        }

        
        public async Task<List<Mascota>> ObtenerTodasLasMascotasAsync()
        {
            return await Connection.Table<Mascota>().ToListAsync();
        }
        public async Task<int> InsertarMascotaAsync(Mascota mascota)
        {
            return await Connection.InsertAsync(mascota);
        }


        public async Task ActualizarMascotaAsync(Mascota mascota)
        {
            await Connection.UpdateAsync(mascota);
        }

        public async Task EliminarMascotaAsync(Mascota mascota)
        {
            await Connection.DeleteAsync(mascota);
        }

        //// Convierte una imagen a bytes para su almacenamiento
        //public static byte[] ImageToBytes(ImageSource imageSource)
        //{
        //    StreamImageSource streamImageSource = (StreamImageSource)imageSource;
        //    System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
        //    Task<Stream> task = streamImageSource.Stream(cancellationToken);
        //    Stream stream = task.Result;
        //    MemoryStream ms = new MemoryStream();
        //    stream.CopyTo(ms);
        //    return ms.ToArray();
        //}

        //// Convierte bytes a una imagen para su visualización
        //public static ImageSource BytesToImage(byte[] bytes)
        //{
        //    return ImageSource.FromStream(() => new MemoryStream(bytes));
        //}

    }
}
