using Restaurante.Entities;

namespace Restaurante.Repository.Interfaces
{
    public interface IMesaRepository : IRepository<Mesas>
    {
        Task<Mesas> GetByCodigoMesa(string codigo);

    }
}
