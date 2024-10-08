using Microsoft.AspNetCore.Mvc;
using Restaurante.DTo;
using Restaurante.Entities;
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


        [HttpPatch("CerrarMesa")]

        public async Task<ActionResult<MesasDto>> CerrarMesa (int mesaId)
        {
            MesasDto mesaDto = await _mesaService.CerrarMesa(mesaId);
            return mesaDto;
        }

    }
}
