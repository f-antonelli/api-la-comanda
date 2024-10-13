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
            string authorizationHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();

                try
                {
                    string rol = GetClaimValueFromJwt(token, "Rol");

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
                catch (Exception ex)
                {
                    // Maneja el error, por ejemplo:
                    context.Result = new UnauthorizedObjectResult(ex.Message);
                    return;
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
        public string GetClaimValueFromJwt(string token, string claimName)
        {
            // Verificar si el token es válido
            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Empty token");
            }

            // Eliminar las comillas dobles si están presentes
             token = token.Trim('"');

            try
            {
                // Usar una librería para decodificar el token JWT
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);

                // Obtener el claim por nombre
                var claim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == claimName);
                return claim?.Value;
            }
            catch (ArgumentException ex)
            {
                // Manejar el error de token mal formado
                throw new Exception($"Token mal formado: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                throw new Exception($"Error al procesar el token: {ex.Message}");
            }
        }


    }
}
