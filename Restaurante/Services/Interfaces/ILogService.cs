

using Restaurante.Dto.Login;
using Restaurante.Entities;

namespace Restaurante.Service.Interface
{
    public interface ILogService
    {
        Task<Empleados> GetUsuarioByUserPass(string user, string pass);

        Task<Object> LogIn(LoginRequestDTO login);
        string GetClaimValueFromJwt(string token, string claimName);


    }
}
