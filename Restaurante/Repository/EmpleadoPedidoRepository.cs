using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;

namespace Restaurante.Repository
{
    public class EmpleadoPedidosRepository 
    {
        private readonly DataContext _context;
        public EmpleadoPedidosRepository(DataContext context) {
            _context = context;
        }

        public async Task<EmpleadoPedidos> GetById(int id)
        {
            return await _context.EmpleadoPedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async void Delete(EmpleadoPedidos entity)
        {
            _context.EmpleadoPedidos.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Edit(EmpleadoPedidos entity)
        {
            _context.EmpleadoPedidos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmpleadoPedidos>> GetAll()
        {
            return await _context.EmpleadoPedidos.ToListAsync();
        }

        public async Task Add(EmpleadoPedidos entity) {

            await _context.EmpleadoPedidos.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
