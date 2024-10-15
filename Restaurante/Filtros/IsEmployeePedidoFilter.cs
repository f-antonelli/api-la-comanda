using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurante.Entities.Enums;
using Restaurante.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurante.Filtros
{
    public class IsEmployeePedidoFilter : ActionFilterAttribute
    {

        private readonly IPedidoRepository _pedidoRepository;
        public IsEmployeePedidoFilter(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
  
            var sector = context.HttpContext.User.FindFirst("Sector")?.Value;
            string idsector = context.ActionArguments["idSector"].ToString();
            int idsectorInt = int.Parse(idsector);

            Sectores sectorSelected = (Sectores)idsectorInt;
            
            Sectores ESector = Enum.Parse<Sectores>(sector);

            if (ESector == sectorSelected)
            {
                await next();

            }
            else
            {
                context.Result = new UnauthorizedObjectResult("No tienes permisos para realizar esta accion");
                return;
            }

        }    

    }
}
