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
        public void Delete(Productos entity)
        {
            _context.Productos.Remove(entity);
            _context.SaveChanges();

        }

        public void Edit(Productos entity)
        {
            _context.Productos.Update(entity);
            _context.SaveChanges();
        }

        public async Task<List<Productos>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
