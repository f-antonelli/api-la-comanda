
using Restaurante.Repository.Interfaces;

namespace Restaurante
{
    public interface IUnitOfWork : IDisposable
    {
        IPedidoRepository PedidoRepository { get; }
 
        Task<int> Save();
    }
}
