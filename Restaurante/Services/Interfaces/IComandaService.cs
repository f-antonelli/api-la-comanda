using Restaurante.DTo;

namespace Restaurante.Services.Interfaces
{
    public interface IComandaService
    {
        Task<ComandasDto> Create (ComandaCreateDto dto);
     
    }
}
