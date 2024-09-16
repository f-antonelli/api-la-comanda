using Restaurante.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Mesas : ClaseBase
    {
        public string Codigo { get; set; }
        public EstadosMesa Estado { get; set; }
    }
}
