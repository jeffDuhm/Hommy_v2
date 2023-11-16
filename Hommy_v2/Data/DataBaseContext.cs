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
        // Conexion
        public SQLiteAsyncConnection Connection { get; set; }

        public DataBaseContext(string path)
        {
            Connection = new SQLiteAsyncConnection(path);

            //Tablas
            Connection.CreateTableAsync<Mascota>().Wait();
            Connection.CreateTableAsync<Solicitud>().Wait();
            Connection.CreateTableAsync<Usuario>().Wait();
        }

        // CRUD - MASCOTAS

        /* Method ->  SELECT BUSCAR*/
        public async Task<Mascota> ObtenerMascotaPorId(int id)
        {
            return await Connection.Table<Mascota>()
                .Where(m => m.ID == id)
                .FirstOrDefaultAsync();
        }

        /* Method ->  SELECT */
        public async Task<List<Mascota>> ObtenerTodasLasMascotasAsync()
        {
            return await Connection.Table<Mascota>().ToListAsync();
        }

        /* Method ->  GUARDAR Y ACTUALIZAR*/
        public async Task<int> InsertarMascotaAsync(Mascota mascota)
        {
            return await Connection.InsertAsync(mascota);
        }

        public async Task<int> ActualizarMascotaAsync(Mascota mascota)
        {

            return await Connection.UpdateAsync(mascota);

        }

        /* Method ->  ELIMINAR */
        public async Task<int> EliminarMascotaAsync(Mascota mascota)
        {
            return await Connection.DeleteAsync(mascota);
        }


        public async Task ActualizarListaMascotas()
        {
            // Lógica para actualizar la lista de mascotas desde la base de datos
            await App.Context.ObtenerTodasLasMascotasAsync();
        }


        // CRUD - SOLICITUDES

        /* Method ->  SELECT BUSCAR*/
        public Task<Solicitud> ObtenerSolicitudIdAsync(int id)
        {
            return Connection.Table<Solicitud>()
                .Where(s => s.SolicitudID == id)
                .FirstOrDefaultAsync();
        }

        /* Method ->  SELECT */
        public Task<List<Solicitud>> ObtenerSolicitud()
        {
            return Connection.Table<Solicitud>().ToListAsync();
        }

        /* Method ->  GUARDAR Y ACTUALIZAR*/
        public Task<int> GuardarSolicitudAsync(Solicitud solicitud)
        {
            if (solicitud.SolicitudID != 0)
            {
                return Connection.UpdateAsync(solicitud);
            }
            else
            {
                return Connection.InsertAsync(solicitud);

            }

        }

        public async Task ActualizarEstadoSolicitudAsync(int solicitudId, string nuevoEstado)
        {
            var solicitud = await Connection.Table<Solicitud>()
                .Where(s => s.SolicitudID == solicitudId)
                .FirstOrDefaultAsync();

            if (solicitud != null)
            {
                solicitud.Estado = nuevoEstado;
                await Connection.UpdateAsync(solicitud);
            }
        }


        /* Method ->  ELIMINAR */
        public Task<int> EliminarSolicitudAsync(Solicitud solicitud)
        {
            return Connection.DeleteAsync(solicitud);
        }

        public async Task<int> ActualizarSolicitudAsync(Solicitud solicitud)
        {

            return await Connection.UpdateAsync(solicitud);

        }


        // CRUD - USUARIOS

        /* Method ->  SELECT BUSCAR*/
        public Task<Usuario> GetUserModelAsync(int id)
        {
            return Connection.Table<Usuario>()
                .Where(i => i.UsuarioID == id)
                .FirstOrDefaultAsync();
        }

        /* Method ->  SELECT */
        public Task<List<Usuario>> GetUserModel()
        {
            return Connection.Table<Usuario>().ToListAsync();
        }

        /* Method ->  GUARDAR Y ACTUALIZAR*/
        public Task<int> GuardarUsuarioAsync(Usuario usuario)
        {
            if (usuario.UsuarioID != 0)
            {
                return Connection.UpdateAsync(usuario);
            }
            else
            {
                return Connection.InsertAsync(usuario);

            }

        }

        public Task<List<Usuario>> ValidarUsuarios(string correo, string contrasennia)
        {
            return Connection.QueryAsync<Usuario>("SELECT * FROM Usuario WHERE Correo = '" + correo + "'AND Contrasennia = '" + contrasennia + "'");
        }
    }
}
