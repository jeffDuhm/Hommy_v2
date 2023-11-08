using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;


namespace Hommy_v2.Services
{
    public class ConvertidorImagen: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] bytes)
            {
                ImageSource imageSource = ImageSource.FromStream(() => new System.IO.MemoryStream(bytes));
                return imageSource ;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        {
            throw new NotImplementedException();
        }
    }
}
