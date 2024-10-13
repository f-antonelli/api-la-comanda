using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurante.Entities.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurante.Filtros
{
    public class AccessFilter : ActionFilterAttribute
    {
        private readonly Roles [] _roles;

        public AccessFilter(params Roles[] roles)
        {
            _roles = roles;
        }

    

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
  
            var rol = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value; // Usa ClaimTypes.Role
            Roles ERol = Enum.Parse<Roles>(rol);

            if (_roles.Contains(ERol))
            {
                await next();

            }
            else
            {
                throw new UnauthorizedAccessException();
            }

        }    

    }
}
