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
    public partial class SolicitudesPage : ContentPage
    {
        public SolicitudesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();


        }

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {

        }

        private void MascotasListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void BtnEliminarMascotaClicked(object sender, EventArgs e)
        {

        }
    }
}