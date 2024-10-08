﻿using Restaurante.Entities.Enums;

namespace Restaurante.Dto.Pedido
{
    public class PedidoResponseDto
    {
        public int ComandaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public EstadosPedido Estado { get; set; }
        public DateTime FechaCreación { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public TimeSpan TiempoEstimado { get; set; }
    }
}
