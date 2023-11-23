using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Hommy_v2.ViewModels;
using Android.Content;

namespace Hommy_v2.Droid
{
    [Activity(Label = "Hommy", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class FileViewer : IFileViewer
    {
        public void OpenFile(string filePath)
        {
            try
            {
                // Crear un intent para abrir el archivo
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(Android.Net.Uri.Parse("file://" + filePath), GetMimeType(filePath));
                intent.SetFlags(ActivityFlags.NewTask);

                // Obtener el contexto actual
                Context context = Android.App.Application.Context;

                // Iniciar la actividad con el intent
                context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir al intentar abrir el archivo
                Console.WriteLine("Error al abrir el archivo: " + ex.Message);
            }
        }

        private string GetMimeType(string filePath)
        {
            // Obtener el tipo MIME del archivo
            string extension = System.IO.Path.GetExtension(filePath).ToLower();
            string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            return mimeType ?? "*/*";
        }
    }
    
}