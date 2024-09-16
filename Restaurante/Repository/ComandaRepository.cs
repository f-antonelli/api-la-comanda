using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;

namespace Restaurante.Repository
{
    public class ComandaRepository
    {
        private readonly DataContext _context;
        public ComandaRepository(DataContext context) {
            _context = context;
        }

        public async Task<Comandas> GetById(int id)
        {
            return await _context.Comandas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task Delete(Comandas entity)
        {
            _context.Comandas.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(Comandas entity)
        {
            _context.Comandas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comandas>> GetAll()
        {
            return await _context.Comandas.ToListAsync();
        }

        public async Task Add(Comandas entity) {

            await _context.Comandas.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
