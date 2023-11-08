using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hommy_v2.Data;
using Hommy_v2.Models;
using Hommy_v2.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Hommy_v2.Views
{
    public partial class RegistroMascotaPage : ContentPage
    {
        private int mascotaID;
        private byte[] fotoBytes;
        private Mascota _mascota; // Variable para mantener la mascota actual
        public RegistroMascotaPage(Mascota mascota= null)
        {
            InitializeComponent();
            _mascota = mascota; // Asigna la mascota proporcionada
            

        }
        

        //-------------------------


        private async void SubirImagenClicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No soportado", "La selección de fotos no es soportada", "Ok");
                return;
            }

            var opciones = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var imagenSeleccionada = await CrossMedia.Current.PickPhotoAsync(opciones);

            if (imagenSeleccionada == null)
                return;

            ImagenMascota.Source = ImageSource.FromStream(() => imagenSeleccionada.GetStream());

            fotoBytes = RegistroMascotasViewModel.ImageToBytes(imagenSeleccionada.GetStream());
        }

        private async void BtnGuardarMascotaClicked(object sender, EventArgs e)
        {

            try
            {
                if (_mascota == null)
                {
                    // Crear una nueva mascota
                    _mascota = new Mascota
                    {
                        Foto = fotoBytes,
                        Nombre = nombre.Text,
                        Raza = raza.Text,
                        Edad = edad.Text,
                        Sexo = sexo.Text,
                        Especie = especie.Text,
                        Tamannio = tamannio.Text,
                        Descripcion = descripcion.Text
                    };
                }
                else
                {
                    // Actualizar una mascota existente
                    _mascota.Foto = fotoBytes;
                    _mascota.Nombre = nombre.Text;
                    _mascota.Raza = raza.Text;
                    _mascota.Edad = edad.Text;
                    _mascota.Sexo = sexo.Text;
                    _mascota.Especie = especie.Text;
                    _mascota.Tamannio = tamannio.Text;
                    _mascota.Descripcion = descripcion.Text;
                }

                var result = await App.Context.InsertarMascotaAsync(_mascota);

                if (result == 1)
                {
                    Mascota mascotaRecuperada = await App.Context.ObtenerMascotaPorId(_mascota.ID);
                    if (mascotaRecuperada.Foto != null && mascotaRecuperada.Foto.Length > 0)
                    {
                        await DisplayAlert("Éxito", "Se ha guardado la foto", "Aceptar");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo registrar", "Aceptar");
                    }
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo registrar", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

            //try
            //{

            //    var mascota = new Mascota
            //    {

            //        Foto = fotoBytes,
            //        Nombre = nombre.Text,
            //        Raza = raza.Text,
            //        Edad = edad.Text,
            //        Sexo = sexo.Text,
            //        Especie = especie.Text,
            //        Tamannio = tamannio.Text,
            //        Descripcion = descripcion.Text
            //    };

            //    var result = await App.Context.InsertarMascotaAsync(mascota);

            //    if (result == 1)
            //    {
            //        Mascota mascotaRecuperada = await App.Context.ObtenerMascotaPorId(mascota.ID);
            //        if (mascotaRecuperada.Foto != null && mascotaRecuperada.Foto.Length > 0)
            //        {
            //            await DisplayAlert("Éxito", "Se ha guardado la foto", "Aceptar");
            //        }
            //        else
            //        {
            //            await DisplayAlert("Error", "No se pudo registrar", "Aceptar");
            //        }
            //        await Navigation.PopAsync();

            //    }
            //    else
            //    {
            //        await DisplayAlert("Error", "No se pudo registrar", "Aceptar");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("Error", ex.Message, "Aceptar");
            //}
        }
    }
}