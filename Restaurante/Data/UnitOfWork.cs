
using Restaurante.Data;
using Restaurante.Repository.Interfaces;

namespace Restaurante
{
    public class UnitOfWork : IUnitOfWork
    {

        public IPedidoRepository PedidoRepository { get; }

        private readonly DataContext _context;

        public UnitOfWork(DataContext context,
        IPedidoRepository pedidoRepository)
        {
            _context = context;
            PedidoRepository = pedidoRepository;
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
