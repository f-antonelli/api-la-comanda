using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;

namespace Restaurante.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto);
        Task Delete(string id);
        Task Update(string id, PedidoResponseDto pedidoDto);
        Task<IEnumerable<PedidoResponseDto>> GetAll();
        Task<PedidoResponseDto> GetById(string id);

        Task<PedidoResponseDto> ActualizarAPreparación(int idPedido, int tiempoEstimadoMinutos);
        Task<PedidoResponseDto> ActualizarAListoParaServir(int idPedido, int idEmpleado);
        Task<TimeSpan> ClienteMiraPedido(string codigoPedido, string codigoMesa);
        Task<List<PedidoResponseDto>> PedidosPendientesPorSector(int idSector);

        Task ServirPedidos();

        Task<IEnumerable<PedidoResponseDto>> Top5ProductosMasVendidos();
        Task<IEnumerable<PedidoResponseDto>> Top5ProductosMenosVendidos();
        Task<IEnumerable<Pedidos>> PedidosFueraDeTiempo();
        Task<List<SectorOperacionDto>> ObtenerOperacionesPorSector();
        Task<List<SectorConEmpleadosDto>> OperacionesPorEmpleadoYSector();
    }
}
