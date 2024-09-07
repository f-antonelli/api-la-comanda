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
    }
}
