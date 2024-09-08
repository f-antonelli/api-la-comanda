using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly ComandaRepository _comandaRepository;

        // Inyectar el repositorio a través del constructor
        public PedidosController(ComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        // Acción para obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await _comandaRepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }

   
        [HttpGet("update")]
        public async Task<ActionResult<Productos>> update(int id)
        {
            var pedido = await _comandaRepository.GetById(id);
            pedido.NombreCliente = "Rojelio";


            await _comandaRepository.Edit(pedido);


            return Ok(); // Devolver el producto
        }
        [HttpGet("add")]
        public async Task<ActionResult<Empleados>> add()
        {
            var newProd = new Comandas();
            newProd.MesaId = 2;
            newProd.NombreCliente = "asd";
            await _comandaRepository.Add(newProd);
           


            return Ok(); // Devolver el producto
        }
        [HttpGet("delete")]
        public async Task<ActionResult<Productos>> delete(int id)
        {
            var producto = await _comandaRepository.GetById(id);

            await _comandaRepository.Delete(producto);
           

            return Ok(); // Devolver el producto
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var producto = await _comandaRepository.GetAll();

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
