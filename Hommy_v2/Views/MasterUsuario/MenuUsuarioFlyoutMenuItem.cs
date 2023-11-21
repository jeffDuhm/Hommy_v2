using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hommy_v2.Views.MasterUsuario
{
    public class MenuUsuarioFlyoutMenuItem
    {
        public MenuUsuarioFlyoutMenuItem()
        {
            TargetType = typeof(MenuUsuarioFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon {  get; set; }
        public Type TargetType { get; set; }
    }
}