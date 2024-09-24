namespace Restaurante.Entities
{
    public class EmpleadoPedidos : ClaseBase
    {
        public Empleados  Empleado { get; set; }
        public int EmpleadoId { get; set; }
        public Pedidos Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}
