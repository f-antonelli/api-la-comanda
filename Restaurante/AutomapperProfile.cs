using AutoMapper;
using Restaurante.Dto.Pedido;
using Restaurante.Entities;

namespace Restaurante
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Pedidos, PedidoCreateRequestDto>();
        }
    }
}
