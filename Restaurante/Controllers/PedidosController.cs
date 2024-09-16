using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto.Pedido;
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

        // Acción para obtener un producto por ID
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Productos>> GetProductoById(int id)
        //{
        //    var producto = await _comandaRepository.GetById(id);

        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(producto); // Devolver el producto
        //}

   
        //[HttpGet("update")]
        //public async Task<ActionResult<Productos>> update(int id)
        //{
        //    var pedido = await _comandaRepository.GetById(id);
        //    pedido.NombreCliente = "Rojelio";


        //    await _comandaRepository.Edit(pedido);


        //    return Ok(); // Devolver el producto
        //}

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
        //[HttpGet("delete")]
        //public async Task<ActionResult<Productos>> delete(int id)
        //{
        //    var producto = await _comandaRepository.GetById(id);

        //    await _comandaRepository.Delete(producto);
           

        //    return Ok(); // Devolver el producto
        //}
        //[HttpGet("GetAll")]
        //public async Task<ActionResult<Productos>> GetAll()
        //{
        //    var producto = await _comandaRepository.GetAll();

        //    if (producto == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(producto); // Devolver el producto
        //}

        [HttpGet("MasVendido")]
        public Task MasVendido()
        {
            throw new NotImplementedException();
        }
        [HttpGet("MenosVendido")]
        public Task MenosVendido()
        {
            throw new NotImplementedException();
        }
        [HttpGet("EntregadoFueraDeTiempo")]
        public Task EntregadoFueraDeTiempo()
        {
            throw new NotImplementedException();
        }
    }
}
