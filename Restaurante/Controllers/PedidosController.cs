using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly PedidoRepository _pedidoRepository;

        // Inyectar el repositorio a través del constructor
        public PedidosController(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        // Acción para obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await _pedidoRepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }
        [HttpGet("update")]
        public async Task<ActionResult<Productos>> update(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);
            pedido.Cantidad = 500;
            await _pedidoRepository.Edit(pedido);


            return Ok(); // Devolver el producto
        }
        [HttpGet("add")]
        public async Task<ActionResult<Productos>> add()
        {
            var newProd = new Pedidos();
            newProd.ComandaId = 1;
            newProd.ProductoId = 2;
            await _pedidoRepository.Add(newProd);
           


            return Ok(); // Devolver el producto
        }
        [HttpGet("delete")]
        public async Task<ActionResult<Productos>> delete(int id)
        {
            var producto = await _pedidoRepository.GetById(id);

            await _pedidoRepository.Delete(producto);
           

            return Ok(); // Devolver el producto
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var producto = await _pedidoRepository.GetAll();

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }

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
