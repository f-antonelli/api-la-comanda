using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.DTo.Pedido;
using Restaurante.Entities;

namespace Restaurante.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto);
        Task Delete(string id);
        Task Update(string id, PedidoUpdateRequestDto pedidoUpdateDto);
        Task<IEnumerable<Pedidos>> GetAll();
        Task<Pedidos> GetById(string id);
        Task<IEnumerable<PedidosDto>> Top5ProductosMasVendidos();
        Task<IEnumerable<PedidosDto>> Top5ProductosMenosVendidos();
        Task<IEnumerable<Pedidos>> PedidosFueraDeTiempo();
        Task<List<SectorOperacionDto>> ObtenerOperacionesPorSector();
        Task<List<SectorConEmpleadosDto>> OperacionesPorEmpleadoYSector();
    }
}
