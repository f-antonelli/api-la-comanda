using AutoMapper;
using Restaurante.Dto.Pedido;
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
            pedido.FechaCreación = DateTime.Now;
            pedido.FechaFinalizacion = pedido.FechaCreación + pedido.TiempoEstimado;

            await _unitOfWork.PedidoRepository.Add(pedido);
           return _mapper.Map<PedidoResponseDto>(pedido);
        }
    }
}
