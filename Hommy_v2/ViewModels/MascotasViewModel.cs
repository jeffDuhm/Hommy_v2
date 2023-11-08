using Hommy_v2.Models;
using Hommy_v2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hommy_v2.ViewModels
{
    public class MascotasViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Mascota> _mascotas;

        public ObservableCollection<Mascota> Mascotas
        {
            get { return _mascotas; }
            set
            {
                _mascotas = value;
                OnPropertyChanged(nameof(Mascotas));
            }
        }

        public ICommand EditarMascotaCommand => new Command<Mascota>(async (mascota) =>
        {
            if (mascota != null)
            {
                // Navegar a la página de registro y pasar la mascota seleccionada como parámetro
                await App.Current.MainPage.Navigation.PushAsync(new RegistroMascotaPage(mascota.ID));
            }
        });



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MascotasViewModel()
        {


        }



    }
}
