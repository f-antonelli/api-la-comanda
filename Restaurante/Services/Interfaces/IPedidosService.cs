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
<<<<<<< HEAD
        Task Update(string id, PedidoUpdateRequestDto pedidoUpdateDto);
        Task<IEnumerable<Pedidos>> GetAll();
        Task<Pedidos> GetById(string id);
        Task<IEnumerable<PedidosDto>> Top5ProductosMasVendidos();
        Task<IEnumerable<PedidosDto>> Top5ProductosMenosVendidos();
=======
        Task Update(string id, PedidoResponseDto pedidoDto);
        Task<IEnumerable<PedidoResponseDto>> GetAll();
        Task<PedidoResponseDto> GetById(string id);

        Task<PedidoResponseDto> ActualizarAPreparación(int idPedido, int tiempoEstimadoMinutos);
        Task<PedidoResponseDto> ActualizarAListoParaServir(int idPedido, int idEmpleado);
        Task<TimeSpan> ClienteMiraPedido(string codigoPedido, string codigoMesa);
        Task<List<PedidoResponseDto>> PedidosPendientesPorSector(int idSector);

        Task ServirPedidos();

        Task<List<ProductoResponseDto>> Top5ProductosMasVendidos();
        Task<List<ProductoResponseDto>>  Top5ProductosMenosVendidos();
>>>>>>> Final
        Task<IEnumerable<Pedidos>> PedidosFueraDeTiempo();
        Task<List<SectorOperacionDto>> ObtenerOperacionesPorSector();
        Task<List<SectorConEmpleadosDto>> OperacionesPorEmpleadoYSector();
    }
}
