using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Repository.Interfaces;

namespace Restaurante.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _context;
    
        public Repository(DataContext context)
        {
            _context = context;
        }
     
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
