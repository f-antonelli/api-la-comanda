using AutoMapper;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
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

        public async Task<Empleados> Create(EmpleadosDto empleadosDto)
        {
            var empleado = _mapper.Map<Empleados>(empleadosDto);

            await _unitOfWork.EmpleadoRepository.Add(empleado);
            return empleado;
        }

        public async Task Delete(string id)
        {
            var empleado = await _unitOfWork.EmpleadoRepository.GetById(int.Parse(id));

            if (empleado == null)
            {
                throw new Exception("El empleado no existe.");
            }

            _unitOfWork.EmpleadoRepository.Delete(empleado);
        }
    }
}
