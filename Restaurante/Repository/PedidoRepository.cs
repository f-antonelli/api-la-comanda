using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;
using Restaurante.Repository.Interfaces;

namespace Restaurante.Repository
{
    public class PedidoRepository:IPedidoRepository
    {
        private readonly DataContext _context;
        public PedidoRepository(DataContext context) {
            _context = context;
        }

        public async Task<Pedidos> GetById(int id)
        {
            return await _context.Pedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async void Delete(Pedidos entity)
        {
            _context.Pedidos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Edit(Pedidos entity)
        {
            _context.Pedidos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pedidos>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task Add(Pedidos entity) {

            await _context.Pedidos.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
