using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.DTo.Pedido;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Filtros;
using Restaurante.Repository;
using Restaurante.Services;
using Restaurante.Services.Interfaces;

namespace Restaurante.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

        [AccessFilter(Roles.Socio)]
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoResponseDto>> GetPedidoById(string id)
        {
            try
            {
                var pedido = await _pedidosService.GetById(id);

                if (pedido == null)
                {
                    return NotFound();
                }
<<<<<<< HEAD
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<Productos>> update(string id, PedidoUpdateRequestDto pedidoUpdateDto)
        {
            try
            {
                await _pedidosService.Update(id, pedidoUpdateDto);
                return Ok(true);

=======
                if(pedido.TiempoEstimado == new TimeSpan())
                {
                    return NotFound("No hay un tiempo estimado");
                }
                return Ok(pedido.TiempoEstimado);
>>>>>>> Final
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    
        [AccessFilter(Roles.Mozo)]
        [HttpPost("add")]
        public async Task<ActionResult<PedidoResponseDto>> CreatePedido(PedidoCreateRequestDto pedidoCreateDto)
        {
            try
            {
                var result = await _pedidosService.Create(pedidoCreateDto);

                if (result != null)
                    return Ok(result);

                return BadRequest(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
   
        [AccessFilter(Roles.Socio)]

        [HttpGet("getAll")]
        public async Task<ActionResult<PedidoResponseDto>> GetAll()
        {
            var productos = await _pedidosService.GetAll();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }
        [AccessFilter(Roles.Cocinero,Roles.Bartender, Roles.Cervecero)]
        [ServiceFilter(typeof(IsEmployeePedidoFilter))]

        [HttpPut("ActualizarAPreparación")]
        public async Task<ActionResult<PedidoResponseDto>> ActualizarAPreparación(int idPedido, int tiempoEstimado)
        {
            var pedido = await _pedidosService.ActualizarAPreparación(idPedido, tiempoEstimado);

           

            return Ok(pedido);
        }

        [AccessFilter(Roles.Cocinero, Roles.Bartender, Roles.Cervecero)]
        [ServiceFilter(typeof(IsEmployeePedidoFilter))]

        [HttpPut("ActualizarAListoParaServir")]
        public async Task<ActionResult<PedidoResponseDto>> ActualizarAListoParaServir(int idPedido)
        {
            var pedido = await _pedidosService.ActualizarAListoParaServir(idPedido, 1);

            return Ok(pedido);
        }
        [AllowAnonymous]
        [HttpGet("ClienteMiraPedido")]
        public async Task<ActionResult<TimeSpan>> ClienteMiraPedido(string codigoPedido, string codigoMesa)
        {
            var pedido = await _pedidosService.ClienteMiraPedido(codigoPedido,codigoMesa);



            return Ok(pedido);
        }
        [AccessFilter(Roles.Mozo)]
        //actualiza el estado del pedido y de la mesa
        [HttpPut("ServirPedidos")]
        public async Task ServirPedidos()
        {
             await _pedidosService.ServirPedidos();

         }
        [EmployeMatchIdSectorFilter]
        [AccessFilter(Roles.Cocinero, Roles.Bartender, Roles.Cervecero)]
        [HttpGet("PedidosPendientesPorSector")]
        public async Task<ActionResult<List<PedidoResponseDto>>> PedidosPendientesPorSector(int idSector)
        {
            return await _pedidosService.PedidosPendientesPorSector(idSector);

        }


        /*
[AccessFilter(Roles.Mozo)]
[HttpPut("update/{id}")]
public async Task<ActionResult<Productos>> update(string id, PedidoResponseDto pedidoDto)
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
}*/
        /*
        [AccessFilter(Roles.Mozo)]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PedidoResponseDto>> Delete(string id)
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

        }*/
    }
}
