namespace Restaurante.DTo
{
    public class ComandasDto
    {
        public int MesaId { get; set; }
        public MesasDto Mesa { get; set; }
        public string NombreCliente { get; set; }
    }
}
