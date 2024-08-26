using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurante.Entities.Enums;

namespace Restaurante.Entities
{
    public class Productos : ClaseBase
    {
        public Sectores Sector { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; } 
        private int Stock { get; set; } 
        public float Precio { get; set; }
    }
}
