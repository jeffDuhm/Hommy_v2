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


        // Seleccionar Buscador
        public async Task<Mascota> ObtenerMascotaPorId(int id)
        {
            return await Connection.Table<Mascota>()
                .Where(m => m.ID == id)
                .FirstOrDefaultAsync();
        }


        //  Seleccionar
        public async Task<List<Mascota>> ObtenerTodasLasMascotasAsync()
        {
            return await Connection.Table<Mascota>().ToListAsync();
        }

        // Guardar y Actualizar
        public async Task<int> InsertarMascotaAsync(Mascota mascota)
        {
            return await Connection.InsertAsync(mascota);
        }

        public async Task<int> ActualizarMascotaAsync(Mascota mascota)
        {

            return await Connection.UpdateAsync(mascota);

        }

        public async Task<int> EliminarMascotaAsync(Mascota mascota)
        {
            return await Connection.DeleteAsync(mascota);
        }



        public async Task ActualizarListaMascotas()
        {
            // Lógica para actualizar la lista de mascotas desde la base de datos
            await App.Context.ObtenerTodasLasMascotasAsync();
        }

        


    }
}
