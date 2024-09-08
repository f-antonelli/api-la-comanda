using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly MesaRepository _mesaRepository;

        // Inyectar el repositorio a través del constructor
        public PedidosController(MesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }

        // Acción para obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await _mesaRepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }

        [HttpGet("codigo")]
        public async Task<ActionResult<Productos>> codigoMesa(string id)
        {
            var producto = await _mesaRepository.GetByCodigoMesa(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }
        [HttpGet("update")]
        public async Task<ActionResult<Productos>> update(int id)
        {
            var pedido = await _mesaRepository.GetById(id);
            
            await _mesaRepository.Edit(pedido);


            return Ok(); // Devolver el producto
        }
        [HttpGet("add")]
        public async Task<ActionResult<Productos>> add()
        {
            var newProd = new Mesas();
            newProd.Codigo = "asds1";
            await _mesaRepository.Add(newProd);
           


            return Ok(); // Devolver el producto
        }
        [HttpGet("delete")]
        public async Task<ActionResult<Productos>> delete(int id)
        {
            var producto = await _mesaRepository.GetById(id);

            await _mesaRepository.Delete(producto);
           

            return Ok(); // Devolver el producto
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var producto = await _mesaRepository.GetAll();

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
