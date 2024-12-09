using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Repository;
using Restaurante.Services.Interfaces;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InformesController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;
        public InformesController(IPedidosService pedidosService) { 
            _pedidosService = pedidosService;
        }


        [HttpGet("Top5ProductosMasVendidos")]
        public async Task<ActionResult<List<ProductoResponseDto>>> Top5ProductosMasVendidos()
        {
            var productos = await _pedidosService.Top5ProductosMasVendidos();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        
        [HttpGet("Top5ProductosMenosVendidos")]
        public async Task<ActionResult<Productos>> Top5ProductosMenosVendidos()
        {
            var productos = await _pedidosService.Top5ProductosMenosVendidos();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }
        

        /*
        [HttpGet("PedidosFueraDeTiempo")]
        public async Task<ActionResult<Productos>> PedidosFueraDeTiempo()
        {
            var pedidos = await _pedidosService.PedidosFueraDeTiempo();

            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }

        [HttpGet("operacionesPorSector")]
        public async Task<IActionResult> ObtenerOperacionesPorSector()
        {
            var operaciones = await _pedidosService.ObtenerOperacionesPorSector();
            return Ok(operaciones);
        }

        [HttpGet("operacionesPorEmpleadoSector")]
        public async Task<IActionResult> ObtenerOperacionesPorEmpleadoYSector()
        {
            var operaciones = await _pedidosService.OperacionesPorEmpleadoYSector();
            return Ok(operaciones);
        }*/
    }
}
