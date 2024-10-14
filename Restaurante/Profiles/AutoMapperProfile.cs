using AutoMapper;
using Restaurante.Entities;
using Restaurante.DTo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Restaurante.DTo.Empleados;
using Restaurante.Dto.Pedido;
namespace Restaurante.Profiles

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comandas, ComandasDto>().ReverseMap();
            CreateMap<Comandas, ComandaCreateDto>();
            CreateMap<ComandaCreateDto, Comandas>();

            CreateMap<Empleados, EmpleadosDto>().ReverseMap();
            CreateMap<Mesas, MesasDto>()
                .ReverseMap();
            CreateMap<Pedidos, PedidoResponseDto>()
    .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto.Nombre))
        .ReverseMap();

              
            CreateMap<Productos, ProductoDto>().ReverseMap();
            CreateMap<PedidoCreateRequestDto, Pedidos>();
      
        
            
        }
    }
}
