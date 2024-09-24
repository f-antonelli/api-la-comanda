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

        [HttpDelete("delete")]
        public ActionResult<PedidosDto> Delete(PedidosDto pedidoDto)
        {
            try
            {
                var pedido = _pedidosService.Delete(pedidoDto);

                if (pedido != null)
                    return Ok(true);

                return BadRequest(false);
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
    }
}
