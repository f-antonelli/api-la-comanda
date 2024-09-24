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
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

       [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedidoById(string id)
        {
            try
            {
                var pedido = await _pedidosService.GetById(id);

                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<Productos>> update(string id, PedidosDto pedidoDto)
        {
            try
            {
                await _pedidosService.Update(id, pedidoDto);
                return Ok(true);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<PedidoResponseDto>> CreatePedido(PedidoCreateRequestDto pedidoCreateDto)
        {
            try
            {
                var result = await _pedidosService.Create(pedidoCreateDto);

                if (result != null)
                    return Ok(true);

                return BadRequest(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PedidosDto>> Delete(string id)
        {
            try
            {
                await _pedidosService.Delete(id);

            
                    return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var productos = await _pedidosService.GetAll();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpGet("Top5ProductosMasVendidos")]
        public async Task<ActionResult<Productos>> Top5ProductosMasVendidos()
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
    }
}
