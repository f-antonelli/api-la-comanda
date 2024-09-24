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

        public async Task Delete(string id)
        {
            var pedido = await _unitOfWork.PedidoRepository.GetById(int.Parse(id));

            if (pedido == null)
            {
                throw new Exception("El pedido no existe.");
            }

            _unitOfWork.PedidoRepository.Delete(pedido);
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

    }
}
