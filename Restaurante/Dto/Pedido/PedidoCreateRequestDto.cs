namespace Restaurante.Dto.Pedido
{
    public class PedidoCreateRequestDto
    {
        public int MesaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
