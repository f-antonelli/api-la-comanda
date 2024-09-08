using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        private readonly EmpleadoRepository _empleadoRepository;

        // Inyectar el repositorio a través del constructor
        public PedidosController(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        // Acción para obtener un producto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Productos>> GetProductoById(int id)
        {
            var producto = await _empleadoRepository.GetById(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto); // Devolver el producto
        }

   
        [HttpGet("update")]
        public async Task<ActionResult<Productos>> update(int id)
        {
            var pedido = await _empleadoRepository.GetById(id);
            pedido.Nombre = "carmelo";
            await _empleadoRepository.Edit(pedido);


            return Ok(); // Devolver el producto
        }
        [HttpGet("add")]
        public async Task<ActionResult<Empleados>> add()
        {
            var newProd = new Empleados();
            newProd.Nombre = "asd";
            newProd.Password = "asd";
            newProd.Usuario = "asd";
            await _empleadoRepository.Add(newProd);
           


            return Ok(); // Devolver el producto
        }
        [HttpGet("delete")]
        public async Task<ActionResult<Productos>> delete(int id)
        {
            var producto = await _empleadoRepository.GetById(id);

            await _empleadoRepository.Delete(producto);
           

            return Ok(); // Devolver el producto
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var producto = await _empleadoRepository.GetAll();

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
