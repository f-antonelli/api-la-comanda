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
        //agregar comanda
        public int ComandaId { get; set; }
        public Comandas Comanda { get; set; }
        public int ProductoId { get; set; }
        public Productos Producto { get; set; }
        public int Cantidad { get; set; }
        public EstadosPedido Estado { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        
    }
}
