using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Entities;
using Restaurante.Repository.Interfaces;

namespace Restaurante.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DataContext _context;
        public EmpleadoRepository(DataContext context) {
            _context = context;
        }

        public async Task<Empleados> GetById(int id)
        {
            return await _context.Empleados.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async void Delete(Empleados entity)
        {
            _context.Empleados.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async void Edit(Empleados entity)
        {
            _context.Empleados.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empleados>> GetAll()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task Add(Empleados entity) {

            await _context.Empleados.AddAsync(entity);
            await _context.SaveChangesAsync();

        }
    }
}
