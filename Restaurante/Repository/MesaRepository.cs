using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;

namespace Restaurante.Repository
{
    public class MesaRepository
    {
        private readonly DataContext _context;
        public MesaRepository(DataContext context) {
            _context = context;
        }

        public async Task<Mesas> GetById(int id)
        {
            return await _context.Mesas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Mesas> GetByCodigoMesa(string codigo)
        {
            return await _context.Mesas.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }
        public async Task Delete(Mesas entity)
        {
            _context.Mesas.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(Mesas entity)
        {
            _context.Mesas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Mesas>> GetAll()
        {
            return await _context.Mesas.ToListAsync();
        }

        public async Task Add(Mesas entity) {

            await _context.Mesas.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
