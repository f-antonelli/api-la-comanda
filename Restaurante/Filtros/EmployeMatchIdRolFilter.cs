using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurante.Entities.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurante.Filtros
{
    public class EmployeMatchIdFilter : ActionFilterAttribute
    {



        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
  
            var rol = context.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            string idRol = context.ActionArguments["id"].ToString();
            int idRolInt = int.Parse(idRol);

            Roles rolSelected = (Roles)idRolInt;
            
            Roles ERol = Enum.Parse<Roles>(rol);

            if (ERol == rolSelected)
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
