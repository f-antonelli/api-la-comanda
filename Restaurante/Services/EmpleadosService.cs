using AutoMapper;
using Restaurante.Entities;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services
{
    public class EmpleadosService: IEmpleadosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadosService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pedidos>> GetAll()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();
            return _mapper.Map<IEnumerable<Pedidos>>(pedidos);

        }
    }
}
