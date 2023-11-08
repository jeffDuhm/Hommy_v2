﻿using System;
using System.Collections.Generic;
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
            CargarMascotas();
        }

        private async void CargarMascotas()
        {
            var mascotas = await App.Context.ObtenerTodasLasMascotasAsync();
            listaMascotas.ItemsSource = mascotas;
        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            // Aquí puedes escribir la lógica para procesar la búsqueda
            // var keyword = searchBar.Text;
            // Realiza la lógica de búsqueda utilizando la palabra clave ingresada
        }


        private async void RegistrarMascotaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroMascotaPage());
        }
    }
}