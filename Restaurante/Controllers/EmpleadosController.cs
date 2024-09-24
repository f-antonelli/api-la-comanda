using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Services;
using Restaurante.Services.Interfaces;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadosService _empleadosService;

        public EmpleadosController(IEmpleadosService empleadosService)
        {
            _empleadosService = empleadosService;
        }

        [HttpGet()]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var empleados = await _empleadosService.GetAll();

            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empleados>> GetPedidoById(string id)
        {
            try
            {
                var empleado = await _empleadosService.GetById(id);

                if (empleado == null)
                {
                    return NotFound();
                }
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Empleados>> CreateEmpleado(EmpleadosDto empleadoDto)
        {
            try
            {
                var result = await _empleadosService.Create(empleadoDto);

                if (result != null)
                    return Ok(true);

                return BadRequest(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpleadosDto>> Delete(string id)
        {
            try
            {
                await _empleadosService.Delete(id);


                return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("DiasHorarios")]
        public Task GetDiasHorarios()
        {
            throw new NotImplementedException();
        }
        [HttpGet("OperacionesPorSector")]
        public Task OperacionesPorSector()
        {
            throw new NotImplementedException();
        }
        [HttpGet("OperacionesPorEmpleadoYSector")]
        public Task OperacionesPorEmpleadoYSector()
        {

            throw new NotImplementedException();
        }
        [HttpGet("OperacionesPorEmpleado")]
        public Task OperacionesPorEmpleado()
        {
            throw new NotImplementedException();
        }
    }
}
