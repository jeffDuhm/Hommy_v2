using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataChart = Microcharts.ChartEntry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hommy_v2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioRefugioPage : ContentPage
    {
        public InicioRefugioPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<DataChart> datacharlist = new List<DataChart>
            {

                new DataChart(3.4f)
                {
                    Color = SkiaSharp.SKColor.Parse("#FFB256"),
                    TextColor = SkiaSharp.SKColor.Parse("#000000"),
                    Label = "JUL.",
                    ValueLabel = "S/300.00",
                    
                    
                },
                new DataChart(5.4f)
                {
                    Color = SkiaSharp.SKColor.Parse("#FEE08D"),
                    TextColor = SkiaSharp.SKColor.Parse("#000000"),
                    Label = "AGO.",
                    ValueLabel = "S/2040.00"
                },
                new DataChart(4.4f)
                {
                    Color = SkiaSharp.SKColor.Parse("#FFB256"),
                    TextColor = SkiaSharp.SKColor.Parse("#000000"),
                    Label = "SET.",
                    ValueLabel = "S/1000.00"
                },
                new DataChart(6.4f)
                {
                    Color = SkiaSharp.SKColor.Parse("#FEE08D"),
                    TextColor = SkiaSharp.SKColor.Parse("#000000"),
                    Label = "OCT.",
                    ValueLabel = "S/4300.00"
                },
                new DataChart(4.7f)
                {
                    Color = SkiaSharp.SKColor.Parse("#FFB256"),
                    TextColor = SkiaSharp.SKColor.Parse("#000000"),
                    Label = "NOV.",
                    ValueLabel = "S/2003.99"
                },

            };

            GraficaDonaciones.Chart = new Microcharts.BarChart
            {
                Entries = datacharlist
            };
        }
    }
}