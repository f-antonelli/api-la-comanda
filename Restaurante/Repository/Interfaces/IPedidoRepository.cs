using Restaurante.DTo;
using Restaurante.Entities;

namespace Restaurante.Repository.Interfaces
{
    public interface IPedidoRepository: IRepository<Pedidos>
    {
        Task<Pedidos> Adds(Pedidos entity);        

            Task<List<SectorOperacionDto>> OperacionesPorSector();
        Task<List<EmpleadoSectorOperacionDto>> OperacionesPorEmpleadoYSector();
    }
}
