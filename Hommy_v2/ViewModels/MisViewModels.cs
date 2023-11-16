using System;
using System.Collections.Generic;
using System.Text;

namespace Hommy_v2.ViewModels
{
    public class MisViewModels : BaseViewModel
    {
        public RegistroSolicitudViewModel SolicitudVM { get; set; }
        public DetallesSolicitudViewModel DetallesVM { get; set; }

        public MisViewModels()
        {
            SolicitudVM = new RegistroSolicitudViewModel();
            DetallesVM = new DetallesSolicitudViewModel();
        }
    }
}
