using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.DTo.Pedido;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Services
{
    public class PedidosService: IPedidosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto)
        {
           var pedido = _mapper.Map<Pedidos>(pedidoCreateDto);

            pedido.Estado = EstadosPedido.EnPreparación;
            pedido.TiempoEstimado = TimeSpan.Zero;
            pedido.FechaCreación = DateTime.Now;

            await _unitOfWork.PedidoRepository.Add(pedido);
           return _mapper.Map<PedidoResponseDto>(pedido);
        }

        public async Task Delete(string id)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _unitOfWork.PedidoRepository.Delete(pedido);
        }

        public async Task Update(string id, PedidoUpdateRequestDto pedidoDto)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _mapper.Map(pedidoDto, pedido);

            _unitOfWork.PedidoRepository.Edit(pedido);
        }

        public async Task<IEnumerable<Pedidos>> GetAll()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();
            return _mapper.Map<IEnumerable<Pedidos>>(pedidos);
         
        }

        public async Task<Pedidos> GetById(string id)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            return _mapper.Map<Pedidos>(pedido);
        }

        public async Task<IEnumerable<PedidosDto>> Top5ProductosMasVendidos()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();

            var productosMasVendidos = pedidos
              .GroupBy(p => p.ProductoId)
              .Select(g => new PedidosDto
              {
                  ProductoId = g.Key,                
                  Cantidad = g.Sum(p => p.Cantidad) 
              })
              .OrderByDescending(x => x.Cantidad) 
              .Take(5)                             
              .ToList();

            return productosMasVendidos;
        }

        public async Task<IEnumerable<PedidosDto>> Top5ProductosMenosVendidos()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();

            var productosMenosVendidos = pedidos
              .GroupBy(p => p.ProductoId)
              .Select(g => new PedidosDto
              {
                  ProductoId = g.Key,
                  Cantidad = g.Sum(p => p.Cantidad)
              })
              .OrderBy(x => x.Cantidad)
              .Take(5)
              .ToList();

            return productosMenosVendidos;
        }

        public async Task<IEnumerable<Pedidos>> PedidosFueraDeTiempo()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();


            var pedidosFueraDeTiempo = pedidos
       .Where(p =>
            (p.FechaFinalizacion - p.FechaCreación) < p.TiempoEstimado)
         .Select(p => new Pedidos
         {
             Id = p.Id,
             ProductoId = p.ProductoId,
             Cantidad = p.Cantidad,
             Estado = p.Estado,
             FechaCreación = p.FechaCreación,
             FechaFinalizacion = p.FechaFinalizacion, 
             TiempoEstimado = p.TiempoEstimado,
         })
         .ToList();

            return pedidosFueraDeTiempo;
        }

        public async Task<List<SectorOperacionDto>> ObtenerOperacionesPorSector()
        {
            return await _unitOfWork.PedidoRepository.OperacionesPorSector();
        }

        public async Task<List<SectorConEmpleadosDto>> OperacionesPorEmpleadoYSector()
        {
            var datos = await _unitOfWork.PedidoRepository.OperacionesPorEmpleadoYSector();

            var operacionesPorSector = datos
                .GroupBy(d => d.Sector)
                .Select(g => new SectorConEmpleadosDto
                {
                    Sector = g.Key,
                    Empleados = g.GroupBy(x => x.EmpleadoId)
                                 .Select(e => new EmpleadoOperacionDto
                                 {
                                     EmpleadoId = e.Key,
                                     CantidadOperaciones = e.Sum(x => x.CantidadOperaciones)
                                 })
                                 .ToList()
                })
                .ToList();

            return operacionesPorSector;
        }

    }
}
