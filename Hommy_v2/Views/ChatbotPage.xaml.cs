using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatbotPage : ContentPage
    {
        ObservableCollection<string> ChatMessages = new ObservableCollection<string>();
        public ChatbotPage()
        {
            InitializeComponent();
            ChatListView.ItemsSource = ChatMessages;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string mensaje = mensajeusuario.Text;
            ChatMessages.Add("Tu: " + mensaje);

            string respuesta = responderuser(mensaje);
            ChatMessages.Add("ChatBot: " + respuesta);

            mensajeusuario.Text = string.Empty;
        }

        string responderuser(string mensaje)
        {
            mensaje = mensaje.ToLower();

            if (mensaje.Contains("Hola"))
            {
                return "¡Hola! ¿Cómo puedo ayudarte con Hommy hoy?";
            }
            else if (mensaje.Contains("Adiós") || mensaje.Contains("Chau") || mensaje.Contains("Hasta luego") || mensaje.Contains("bye") || mensaje.Contains("Alamos") || mensaje.Contains("Hablamos"))
            {
                return "¡Hasta luego! Si tienes más preguntas, no dudes en volver.";
            }
            else if (mensaje.Contains("cómo estás"))
            {
                return "Estoy bien, gracias por preguntar. ¿En qué puedo asistirte?";
            }
            else if (mensaje.Contains("hommy") && mensaje.Contains("negocio"))
            {
                return "Hommy es un negocio dedicado al desarrollo de aplicaciones móviles para gestionar y apoyar refugios de mascotas. ¿Quieres saber más detalles?";
            }
            else if (mensaje.Contains("funciones") && mensaje.Contains("hommy"))
            {
                return "Hommy ofrece servicios personalizados para refugios de mascotas, incluyendo aplicaciones para la gestión interna y facilitar la adopción de mascotas. ¿Te gustaría conocer más sobre nuestras funciones?";
            }
            else if (mensaje.Contains("visión") && mensaje.Contains("hommy"))
            {
                return " Nuestra visión es convertirnos en la principal plataforma de desarrollo de aplicaciones móviles para refugios de mascotas en todo el mundo, brindando herramientas efectivas que mejoren la vida de las mascotas y faciliten la adopción responsable.";
            }
            else if (mensaje.Contains("porcentaje") && mensaje.Contains("abandono"))
            {
                return " Los porcentajes de abandono de perros varían, pero desafortunadamente, es un problema común en muchas comunidades. ¿Tienes alguna región específica en mente para obtener datos más precisos? Puedes consultar estadísticas actualizadas";
            }
            else
            {
                return "Lo siento, no entiendo. ¿Podrías ser más claro o preguntar sobre algo específico de Hommy?";
            }
        }

    }
}