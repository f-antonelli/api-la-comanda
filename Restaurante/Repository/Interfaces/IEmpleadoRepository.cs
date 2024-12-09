using Restaurante.Entities;

namespace Restaurante.Repository.Interfaces
{
    public interface IEmpleadoRepository: IRepository<Empleados>
    {
        Task<Empleados> GetByUserPass(string usuario, string password);
    }
}
