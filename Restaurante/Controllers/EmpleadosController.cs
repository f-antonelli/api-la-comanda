using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
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
