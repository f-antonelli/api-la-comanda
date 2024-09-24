using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.DTo.Empleados;
using Restaurante.Entities;

namespace Restaurante.Services.Interfaces
{
    public interface IEmpleadosService
    {
        Task<IEnumerable<Empleados>> GetAll();
        Task<Empleados> GetById(string id);
        Task<Empleados> Create(EmpleadosDto empleadosDto);
        Task Delete(string id);
        Task<IEnumerable<EmpleadosIngresoDto>> EmpleadosIngreso();
    }
}
