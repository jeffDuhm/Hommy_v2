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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public byte[] ConvertirImagenABytes(ImageSource imageSource)
        {
            if (imageSource is StreamImageSource streamImageSource)
            {
                System.Threading.CancellationToken cancellationToken = System.Threading.CancellationToken.None;
                Task<Stream> task = streamImageSource.Stream(cancellationToken);
                Stream stream = task.Result;
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public void ConvertirBytesAImage(byte[] bytes)
        {
            MascotaImageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
        }

    }
}
