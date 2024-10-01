namespace Restaurante.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
