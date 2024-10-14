using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Migrations;
using Restaurante.Repository;
using Restaurante.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurante.Services
{
    public class PedidosService: IPedidosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ProductoRepository _productoRepository;

        public PedidosService(IUnitOfWork unitOfWork, IMapper mapper, ProductoRepository productoRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productoRepository = productoRepository;
        }
        /*
         {
  "comandaId": 1,
  "productoId": 1,
  "cantidad": 1
}
        */
        public async Task<PedidoResponseDto> Create(PedidoCreateRequestDto pedidoCreateDto)
        {
            //trae el producto para disminuir el stock
            var producto = await _productoRepository.GetById(pedidoCreateDto.ProductoId);

            if (producto == null) {
                throw new Exception("El producto no existe");
            }
            producto.SetStock(-pedidoCreateDto.Cantidad);

            await _productoRepository.Edit(producto);

            //el dto lo mapea a pedido
           var pedido = _mapper.Map<Pedidos>(pedidoCreateDto);

            pedido.FechaCreación = DateTime.Now;
           
            //guarda el pedido
            Pedidos pedidoAgregado = await _unitOfWork.PedidoRepository.Adds(pedido);

            var rsta = _mapper.Map<PedidoResponseDto>(pedidoAgregado);

           
            return rsta;

            _mapper.Map<PedidoResponseDto>(pedido);
        }

        public async Task Delete(string id)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _unitOfWork.PedidoRepository.Delete(pedido);
            _unitOfWork.Save();
        }

        public async Task Update(string id, PedidoResponseDto pedidoDto)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));
            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _mapper.Map(pedidoDto, pedido);

            _unitOfWork.PedidoRepository.Edit(pedido);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<PedidoResponseDto>> GetAll()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();
            return _mapper.Map<IEnumerable<PedidoResponseDto>>(pedidos);
         
        }

        public async Task<PedidoResponseDto> GetById(string id)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            return _mapper.Map<PedidoResponseDto>(pedido);
        }

        public async Task<IEnumerable<PedidoResponseDto>> Top5ProductosMasVendidos()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();

            var productosMasVendidos = pedidos
              .GroupBy(p => p.ProductoId)
              .Select(g => new PedidoResponseDto
              {
                  ProductoId = g.Key,                
                  Cantidad = g.Sum(p => p.Cantidad) 
              })
              .OrderByDescending(x => x.Cantidad) 
              .Take(5)                             
              .ToList();

            return productosMasVendidos;
        }

        public async Task<IEnumerable<PedidoResponseDto>> Top5ProductosMenosVendidos()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();

            var productosMenosVendidos = pedidos
              .GroupBy(p => p.ProductoId)
              .Select(g => new PedidoResponseDto
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

        public async Task<PedidoResponseDto> ActualizarAPreparación(string codigoPedido, int tiempoEstimadoMinutos)
        {
            //agregar validacion Empleado

            var pedidos = await _unitOfWork.PedidoRepository.GetAll();
            var pedido =  pedidos.Where(x => x.CodigoPedido == codigoPedido).FirstOrDefault();
            if (pedido == null) throw new Exception("El pedido no existe");

            pedido.TiempoEstimado = TimeSpan.FromMinutes(tiempoEstimadoMinutos);
            pedido.ActualizarEstado();

            _unitOfWork.PedidoRepository.Edit(pedido);
            await _unitOfWork.Save();

            var rsta = _mapper.Map<PedidoResponseDto>(pedido);
            return rsta;
        }

        public async Task<PedidoResponseDto> ActualizarAListoParaServir(int idPedido, int idEmpleado)
        {
            //agregar validacion Empleado

            var pedido = await _unitOfWork.PedidoRepository.GetById(idPedido);
            if (pedido == null) throw new Exception("El pedido no existe");
          
            pedido.ActualizarEstado();
            pedido.FechaFinalizacion = DateTime.Now;

            _unitOfWork.PedidoRepository.Edit(pedido);
            await _unitOfWork.Save();

            var rsta = _mapper.Map<PedidoResponseDto>(pedido);
            return rsta;
        }


            public  async Task<TimeSpan> ClienteMiraPedido(string codigoPedido, string codigoMesa)
                {
                    var pedido = await _unitOfWork.PedidoRepository.ClienteMiraPedido(codigoPedido, codigoMesa);

                    var tiempoEstimado = pedido.TiempoEstimado;


                    if (tiempoEstimado != null)
                    {
                        return tiempoEstimado.GetValueOrDefault();
                    }
                    else
                    {
                        throw new Exception("Aun no hay un tiempo estimado");
                    }
                }


            public async Task ServirPedidos()
            {
            var servirPedidos = await _unitOfWork.PedidoRepository.GetListosParaServir();
            await _unitOfWork.Save();
            }

        public async Task<List<PedidoResponseDto>> PedidosPendientesPorSector(int idSector)
        {
            Sectores sectorSelected = (Sectores)idSector;
            if (sectorSelected == Sectores.Otro)
            {
                throw new Exception();
            }

            List<Pedidos> pedido = await _unitOfWork.PedidoRepository.GetAll();
           
            var pedidosFiltrados = pedido.Where(x => x.Producto.Sector == sectorSelected && x.Estado == EstadosPedido.Ordenado).ToList();
            if (pedidosFiltrados == null)
            {
                throw new Exception("no hay pedidos");

            }
            var rsta = _mapper.Map<List<PedidoResponseDto>>(pedidosFiltrados);
            return rsta;

            //throw new NotImplementedException();

        }
    }
}



/*
 
     var pedidos = await _unitOfWork.PedidoRepository.GetAll();

           var pedidoCliente = pedidos.Where(x => x.CodigoPedido == codigoPedido).FirstOrDefault();

           if (pedidoCliente == null)
           {
               throw new Exception("El pedido no existe");
           }

           var comanda = await _unitOfWork.ComandaRepository.GetById(pedidoCliente.ComandaId);

           if (comanda == null)
           {
               throw new Exception("La comanda no existe");
           }

           var mesas = await _unitOfWork.MesaRepository.GetById(comanda.MesaId);

           if (mesas == null)
           {
               throw new Exception("La mesa no existe");
           }
           else if(mesas.Codigo != codigoMesa)
           {
               throw new Exception("La codigo de la mesa no coincide");

           }
           var tiempoEstimado = pedidoCliente.TiempoEstimado;


           if (tiempoEstimado != null)
           {
               return tiempoEstimado.GetValueOrDefault();
           }
           else
           {
               throw new Exception("Aun no hay un tiempoe estimado");
           }
       TimeSpan asd = new TimeSpan(0,0,0);
       return asd;*/