using AutoMapper;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
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

        public Pedidos Delete(PedidosDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedidos>(pedidoDto);
            _unitOfWork.PedidoRepository.Delete(pedido);
            return pedido;
        }

        public async Task Update(string id, PedidosDto pedidoDto)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));
            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _mapper.Map(pedidoDto, pedido);

            _unitOfWork.PedidoRepository.Edit(pedido);
        }

        public async Task<IEnumerable<PedidosDto>> GetAll()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();
            var pedidosDto = _mapper.Map<IEnumerable<PedidosDto>>(pedidos);
            return pedidosDto;
        }

    }
}
