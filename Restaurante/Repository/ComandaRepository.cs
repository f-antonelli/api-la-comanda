using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;
using Restaurante.Repository.Interfaces;

namespace Restaurante.Repository
{
    public class ComandaRepository: IComandaRepository
    {
        private readonly DataContext _context;
        public ComandaRepository(DataContext context) {
            _context = context;
        }

        public async Task<Comandas> GetById(int id)
        {
            return await _context.Comandas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async void Delete(Comandas entity)
        {
            _context.Comandas.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async void Edit(Comandas entity)
        {
            _context.Comandas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comandas>> GetAll()
        {
            return await _context.Comandas.ToListAsync();
        }

        public async Task<Comandas> Add(Comandas entity) {

            await _context.Comandas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
