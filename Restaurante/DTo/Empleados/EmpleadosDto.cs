using Restaurante.Entities.Enums;

namespace Restaurante.DTo.Empleados
{
    public class EmpleadosDto
    {
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public Roles Rol { get; set; }
        public Sectores Sector { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}
