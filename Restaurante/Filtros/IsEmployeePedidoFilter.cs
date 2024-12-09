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

        private readonly IPedidoRepository _pedidosRepository;
        public IsEmployeePedidoFilter(IPedidoRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
  

            var sector = context.HttpContext.User.FindFirst("Sector")?.Value;
            string idPedido = context.ActionArguments["idPedido"].ToString();

            var pedido = await _pedidosRepository.GetById(int.Parse(idPedido));
            Sectores ESector = Enum.Parse<Sectores>(sector);


            if (pedido.Producto.Sector == ESector)
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
