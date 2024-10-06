using AutoMapper;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Repository;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services
{
    public class ComandaService : IComandaService

    {
        private readonly ComandaRepository _comandaRepository;
        private readonly IMapper _mapper;
        public ComandaService(ComandaRepository comandaRepository, IMapper mapper) {
            _comandaRepository = comandaRepository;
            _mapper = mapper;
                }
        public async Task<ComandasDto> Create(ComandaCreateDto dto)
        {
            var comanda = _mapper.Map<Comandas>(dto);

            await _comandaRepository.Add(comanda);

            var comandaResponse = _mapper.Map<ComandasDto>(comanda);
            return comandaResponse;
        }
    }
}

/*
        var empleado = _mapper.Map<Empleados>(empleadosDto);

            await _unitOfWork.EmpleadoRepository.Add(empleado);
            return empleado;
 */