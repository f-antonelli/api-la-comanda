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
        [HttpGet("update")]
        public async Task<ActionResult<Productos>> update(int id)
        {
            var producto = await _productoRepository.GetById(id);
            producto.Nombre = "updATED";
            _productoRepository.Edit(producto);


            return Ok(); // Devolver el producto
        }
        [HttpGet("add")]
        public async Task<ActionResult<Productos>> add()
        {
            var newProd = new Productos();
            newProd.Nombre = "a";
            newProd.Descripcion = "a";
            newProd.SetStock(10);
             _productoRepository.Add(newProd);
           


            return Ok(); // Devolver el producto
        }
        [HttpGet("delete")]
        public async Task<ActionResult<Productos>> delete(int id)
        {
            var producto = await _productoRepository.GetById(1);

            _productoRepository.Delete(producto);
           

            return Ok(); // Devolver el producto
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var producto = await _productoRepository.GetAll();

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
