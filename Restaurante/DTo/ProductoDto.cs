using Restaurante.Entities.Enums;

namespace Restaurante.DTo
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public Sectores Sector { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}
