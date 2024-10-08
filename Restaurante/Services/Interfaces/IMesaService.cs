using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;

namespace Restaurante.Services.Interfaces
{
    public interface IMesaService
    {
        Task<MesasDto> UpdateStatus(int idMesa, EstadosMesa estadoMesa);
        Task<MesasDto> CerrarMesa(int idMesa);
    }
}
