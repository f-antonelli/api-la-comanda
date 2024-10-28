using Microsoft.AspNetCore.Mvc;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Filtros;
using Restaurante.Services.Interfaces;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MesaController : ClaseBase
    {

        private readonly IMesaService _mesaService;
        public MesaController(IMesaService mesaService) {

            _mesaService = mesaService;
        }

        [AccessFilter(Roles.Socio)]
        [HttpPut("CerrarMesa")]

        public async Task<ActionResult<MesasDto>> CerrarMesa (int mesaId)
        {
            MesasDto mesaDto = await _mesaService.CerrarMesa(mesaId);
            return mesaDto;
        }
        [AccessFilter(Roles.Mozo)]
        [HttpPut("UpdateEstadoMesa")]
        public async Task<ActionResult<MesasDto>> UpdateEstadoMesa(int mesaId, EstadosMesa estadoMesa)
        {
            MesasDto mesaDto = await _mesaService.UpdateStatus(mesaId, estadoMesa);
            return mesaDto;
        }
        [AccessFilter(Roles.Socio)]
        [HttpGet()]
        public async Task<ActionResult<List<MesasDto>>> GetAll()
        {
            List<MesasDto> mesaDto = await _mesaService.GetAll();
            return mesaDto;
        }
    }
}
