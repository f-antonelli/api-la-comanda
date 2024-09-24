using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;

namespace Restaurante.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto);
        Pedidos Delete(PedidosDto pedidoDto);
        Task Update(string id, PedidosDto pedidoDto);
        Task<IEnumerable<Pedidos>> GetAll();
        Task<Pedidos> GetById(string id);
    }
}
