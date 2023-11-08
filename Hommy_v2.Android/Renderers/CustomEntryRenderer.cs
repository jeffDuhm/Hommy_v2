using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(Hommy_v2.Droid.CustomEntryRenderer))]
namespace Hommy_v2.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Cambiar el color de la línea inferior del EditText al color personalizado
                // Cambiar el color de la línea inferior del EditText al color personalizado
                Control.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#FEE08D"));


            }
        }
    }
}
