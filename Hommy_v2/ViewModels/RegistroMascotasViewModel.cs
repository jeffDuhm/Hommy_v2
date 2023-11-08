using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hommy_v2.ViewModels
{


    public class RegistroMascotasViewModel : INotifyPropertyChanged
    {
        private ImageSource _mascotaImageSource;

        public ImageSource MascotaImageSource
        {
            get { return _mascotaImageSource; }
            set
            {
                _mascotaImageSource = value;
                OnPropertyChanged(nameof(MascotaImageSource));
            }
        }

        public static byte[] ImageToBytes(Stream stream)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public static ImageSource BytesToImage(byte[] bytes)
        {
            if(bytes != null)
            {
                return ImageSource.FromStream(() => new MemoryStream(bytes));
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
