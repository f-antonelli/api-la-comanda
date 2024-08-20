using Entities.Enums;

namespace Entities
{
    public class Empleados : ClaseBase
    {
        public string Nombre { get;set; }
        public string Usuario { get;set; }
        public string Password { get; set; }
        public Roles Rol { get; set; }
        public Sectores Sector { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}
