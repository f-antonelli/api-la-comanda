﻿using AutoMapper;
using Restaurante.Entities;
using Restaurante.DTo;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Restaurante.DTo.Empleados;
namespace Restaurante.Profiles

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Comandas, ComandasDto>().ReverseMap();
            CreateMap<Empleados, EmpleadosDto>().ReverseMap();
            CreateMap<Mesas, MesasDto>().ReverseMap();
            CreateMap<Pedidos, PedidosDto>().ReverseMap();
            CreateMap<Productos, ProductoDto>().ReverseMap();
        }
    }
}
