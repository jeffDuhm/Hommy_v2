using Hommy_v2.Models;
using Hommy_v2.Services;
using Hommy_v2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MascotasPage : ContentPage
    {

        public MascotasPage()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            searchBar.TextChanged += OnSearchTextChanged;
            CargarMascotas();
          
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            searchBar.TextChanged -= OnSearchTextChanged;
        }

        private async void CargarMascotas()
        {
            var mascotas = await App.Context.ObtenerTodasLasMascotasAsync();
            listaMascotas.ItemsSource = mascotas;

        }

        private async void MascotasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Mascota selectedMascota)
            {
                await Navigation.PushAsync(new RegistroMascotaPage(selectedMascota));

            }
        }


        private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                CargarMascotas(); // Cargar todas las mascotas cuando el texto de búsqueda está vacío
            }

            string keyword = searchBar.Text; // Obtén el término de búsqueda ingresado por el usuario

            // Realiza la búsqueda de las mascotas en función del término de búsqueda
            List<Mascota> mascotas = await App.Context.ObtenerTodasLasMascotasAsync();
            var mascotasFiltradas = mascotas.Where(m => m.Nombre.ToLower().Contains(keyword.ToLower())).ToList();

            // Actualiza la lista de mascotas en tu página con las mascotas filtradas
            listaMascotas.ItemsSource = mascotasFiltradas;
        }



        private async void RegistrarMascotaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroMascotaPage());
        }


        private async void BtnEliminarMascotaClicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Confirmación","¿Está seguro de eliminar el elemento?", "Sí","No"))
            {
                var mascota = (Mascota)(sender as MenuItem).CommandParameter;
                var result = await App.Context.EliminarMascotaAsync(mascota);
                if (result == 1)
                {
                    CargarMascotas();
                }
            }

        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {

        }
    }


}