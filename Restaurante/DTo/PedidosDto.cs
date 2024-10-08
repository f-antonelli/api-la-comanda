﻿using Restaurante.Entities.Enums;
using Restaurante.Entities;
using Restaurante.DTo.Comanda;

namespace Restaurante.DTo
{
    public class PedidosDto
    {
        public int ComandaId { get; set; }
        public ComandaCreateRequestDto Comanda { get; set; }
        public Productos Producto { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public EstadosPedido Estado { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public TimeSpan TiempoEstimado { get; set; }
    }
}
