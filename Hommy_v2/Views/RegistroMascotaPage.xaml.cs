using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hommy_v2.Data;
using Hommy_v2.Models;
using Hommy_v2.Services;
using Hommy_v2.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Hommy_v2.Views
{
    public partial class RegistroMascotaPage : ContentPage
    {
        private ObservableCollection<Mascota> ListaMascotas { get; set; } = new ObservableCollection<Mascota>();
        private byte[] fotoBytes;

        public RegistroMascotaPage()
        {
            InitializeComponent();
               

        }
        public RegistroMascotaPage(Mascota mascota)
        {
        
            // Lógica para editar la mascota con el parámetro proporcionado
            InitializeComponent();
            BindingContext = new RegistroMascotasViewModel();
            // Asegúrate de cargar los datos de la mascota en tus controles de la página
            LoadMascotaData(mascota);
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
        private async void BtnActualizarMascotaClicked(object sender, EventArgs e)
        {
            try
            {

                if (BindingContext is Mascota mascota)
                {
                    // Aquí puedes realizar las actualizaciones necesarias en el objeto 'mascota'
                    mascota.Nombre = nombre.Text;
                    mascota.Foto = fotoBytes;
                    mascota.Raza = raza.Text;
                    mascota.Edad = edad.Text;
                    mascota.Sexo = sexo.Text;
                    mascota.Especie = especie.Text;
                    mascota.Tamannio = tamannio.Text;
                    mascota.Descripcion = descripcion.Text;

                    // Luego, puedes llamar al método de actualización en tu contexto de base de datos
                    var result = await App.Context.ActualizarMascotaAsync(mascota);

                    // Verifica si la operación de actualización tuvo éxito
                    if (result == 1)
                    {
                        // Muestra un mensaje de éxito si la actualización fue exitosa
                        await DisplayAlert("Éxito", "Mascota actualizada correctamente", "Aceptar");
                        // Vuelve a la página anterior después de actualizar
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        // Muestra un mensaje de error si la actualización falló
                        await DisplayAlert("Error", "No se pudo actualizar la mascota", "Aceptar");
                    }
                }
                else
                {
                    // Muestra un mensaje de error si el contexto de enlace no es una mascota válida
                    await DisplayAlert("Error", "La mascota no tiene un contexto de enlace válido", "Aceptar");
                }


            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir durante el proceso de actualización
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }


        private async void BtnGuardarMascotaClicked(object sender, EventArgs e)
        {

            try
            {

                var mascota = new Mascota
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

                var result = await App.Context.InsertarMascotaAsync(mascota);


                if (result == 1)
                {
                    await DisplayAlert("Éxito", "Mascota guardada correctamente", "Aceptar");

                }
                else
                {
                    await DisplayAlert("Éxito", "Se ha registrado su mascota", "Aceptar");
                }

                await Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }

        private void LoadMascotaData(Mascota mascota)
        {
            var convertidorImagen = new ConvertidorImagen();
            ImagenMascota.Source = convertidorImagen.Convert(mascota.Foto, null, null, null) as ImageSource;
            nombre.Text = mascota.Nombre;
            raza.Text = mascota.Raza;
            edad.Text = mascota.Edad;
            sexo.Text = mascota.Sexo;
            especie.Text = mascota.Especie;
            tamannio.Text = mascota.Tamannio;
            descripcion.Text = mascota.Descripcion;
            // Carga la imagen de la mascota en tu control de imagen si es necesario
            fotoBytes = mascota.Foto;

            // Asigna la mascota como el contexto de enlace
            BindingContext = mascota;

        }
    }
}