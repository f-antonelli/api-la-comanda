using Microsoft.AspNetCore.Mvc;
using Restaurante.DTo.Empleados;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Filtros;
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

        [AccessFilter(Roles.Socio, Roles.Bartender)]
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

        [EmployeMatchIdSectorFilter]
        [AccessFilter(Roles.Socio, Roles.Bartender)]
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

        [HttpGet("fechaIngreso")]
        public async Task<ActionResult<Productos>> GetEmpleadoIngreso()
        {
            var empleados = await _empleadosService.EmpleadosIngreso();

            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

    }
}
