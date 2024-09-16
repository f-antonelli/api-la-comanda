using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;

namespace Restaurante.Repository
{
    public class ProductoRepository
    {
        private readonly DataContext _context;
        public ProductoRepository(DataContext context) {
            _context = context;
        }

        public async Task<Productos> GetById(int id)
        {
            return await _context.Productos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task Delete(Productos entity)
        {
            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(Productos entity)
        {
            _context.Productos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Productos>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task Add(Productos entity) {

            await _context.Productos.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
