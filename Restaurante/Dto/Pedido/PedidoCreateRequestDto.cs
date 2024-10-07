namespace Restaurante.Dto.Pedido
{
    public class PedidoCreateRequestDto
    {
        public int ComandaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
