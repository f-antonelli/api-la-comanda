
using Restaurante.Repository.Interfaces;

namespace Restaurante
{
    public interface IUnitOfWork : IDisposable
    {
        IPedidoRepository PedidoRepository { get; }
        IEmpleadoRepository EmpleadoRepository { get; }
 
        Task<int> Save();
    }
}
