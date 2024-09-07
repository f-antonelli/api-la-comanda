using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly ProductoRepository _productoRepository;

        // Inyectar el repositorio a través del constructor
        public PedidosController(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        // Acción para obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await _productoRepository.GetById(id);

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
