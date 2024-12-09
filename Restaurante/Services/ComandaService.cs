using AutoMapper;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Repository;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services
{
    public class ComandaService : IComandaService

    {
        private readonly ComandaRepository _comandaRepository;
        private readonly IMapper _mapper;
        private readonly MesaRepository _mesaRepository;

        public ComandaService(ComandaRepository comandaRepository, IMapper mapper, MesaRepository mesaRepository)
        {
            _comandaRepository = comandaRepository;
            _mapper = mapper;
            _mesaRepository = mesaRepository;
        }
        public async Task<ComandasDto> Create(ComandaCreateDto dto)
        {
              var mesId = dto.MesaId;
            var mesa = await _mesaRepository.GetById(mesId);
            if (mesa.Estado != EstadosMesa.Cerrada) {
                throw new Exception("la mesa no esta disponible actualmente");
            }
            mesa.Estado = EstadosMesa.ClienteEsperandoPedido;
            await _mesaRepository.Edit(mesa);
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