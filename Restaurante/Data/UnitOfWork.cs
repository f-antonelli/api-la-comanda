
using Restaurante.Data;
using Restaurante.Repository.Interfaces;

namespace Restaurante
{
    public class UnitOfWork : IUnitOfWork
    {

        public IPedidoRepository PedidoRepository { get; }
        public IEmpleadoRepository EmpleadoRepository { get; }
        public IComandaRepository ComandaRepository { get; }

        private readonly DataContext _context;

        public UnitOfWork(DataContext context, IPedidoRepository pedidoRepository,
        IEmpleadoRepository empleadoRepository, IComandaRepository comandaRepository)
        {
            _context = context;
            PedidoRepository = pedidoRepository;
            EmpleadoRepository = empleadoRepository;
            ComandaRepository = comandaRepository;
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
