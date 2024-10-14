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
    public class ComandaController : ClaseBase
    {

        private readonly IComandaService _comandaService;
        public ComandaController(IComandaService comandaService) {
            _comandaService = comandaService;

        }
        [AccessFilter(Roles.Mozo)]

        [HttpPost]
        public async Task<ActionResult<ComandasDto>> Create(ComandaCreateDto dto)
        {
            var rsta = await _comandaService.Create(dto);
            return rsta;
        }

    }
}
