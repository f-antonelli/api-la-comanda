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

        public async Task<IEnumerable<Empleados>> GetAll()
        {
            var empleados = await _unitOfWork.EmpleadoRepository.GetAll();
            return _mapper.Map<IEnumerable<Empleados>>(empleados);

        }

        public async Task<Empleados> GetById(string id)
        {
            var empleado = await _unitOfWork.EmpleadoRepository.GetById(int.Parse(id));

            if (empleado == null)
            {
                throw new Exception("El empleado no existe.");
            }

            return _mapper.Map<Empleados>(empleado);
        }
    }
}
