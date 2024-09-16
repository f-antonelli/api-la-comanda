using Restaurante.Dto.Pedido;

namespace Restaurante.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto);

    }
}
