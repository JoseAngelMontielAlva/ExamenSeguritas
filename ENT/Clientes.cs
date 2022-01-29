using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Clientes
    {
        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public string FechaModificacion { get; set; }
        public List<object> Cliente { get; set; }
    }
}
