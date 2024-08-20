using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    internal class Pedidos : ClaseBase
    {
        public string Codigo { get; set; }
        public int ComandaId { get; set; }
        public Comandas Comanda { get; set; }
        public List<Productos> Productos { get; set; }
        public EstadosPedido Estado { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaFinalizacion { get; set; }
    }
}
