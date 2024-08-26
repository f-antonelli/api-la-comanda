using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Entities
{
    public class Comandas : ClaseBase
    {
        public int MesaId { get; set; }
        public Mesas Mesa { get; set; }
        public string NombreCliente { get; set; }
    }
}
