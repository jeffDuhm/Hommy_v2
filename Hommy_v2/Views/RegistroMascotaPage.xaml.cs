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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroMascotaPage : ContentPage
    {
        public RegistroMascotaPage()
        {
            InitializeComponent();
        }


        private async void SubirImagenClicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("No soportado", "La selección de fotos no es soportada", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };

            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImageFile == null)
                return;

            ImagenMascota.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());

            if (BindingContext is RegistroMascotasViewModel viewModel)
            {
                byte[] fotoBytes = viewModel.ConvertirImagenABytes(ImagenMascota.Source);
                viewModel.ConvertirBytesAImage(fotoBytes);
            }

        }

        private async void BtnGuardarMascotaClicked(object sender, EventArgs e)
        {
            try
            {
                
                var mascota = new Mascota
                {
                   
                    Nombre = nombre.Text,
                    Raza = raza.Text,
                    Edad = edad.Text,
                    Sexo = sexo.Text,
                    Especie = especie.Text,
                    Tamannio = tamannio.Text,
                    Descripcion = descripcion.Text
                };

                //mascota.SetImageSource(ImagenMascota.Source);
                if (ImagenMascota.Source is StreamImageSource streamImageSource)
                {
                    System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                    Task<Stream> task = streamImageSource.Stream(cancellationToken);
                    Stream stream = task.Result;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        mascota.Foto = ms.ToArray();
                    }
                }

                var result = await App.Context.InsertarMascotaAsync(mascota);
                if (result == 1)
                { 
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
        }
    }
}