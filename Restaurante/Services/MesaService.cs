using AutoMapper;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Repository;
using Restaurante.Repository.Interfaces;
using Restaurante.Services.Interfaces;
using System.Security.Cryptography;

namespace Restaurante.Services
{
    public class MesaService : IMesaService
    {

        private readonly MesaRepository _mesaRepository;
        private readonly IMapper _mapper;
        public MesaService(MesaRepository mesaRepository, IMapper mapper) {
            _mesaRepository = mesaRepository;
            _mapper = mapper;
        }
        public async Task<MesasDto> CerrarMesa(int idMesa)
        {
            Mesas mesa = await _mesaRepository.GetById(idMesa);

            mesa.Estado = EstadosMesa.Cerrada;
            await _mesaRepository.Edit(mesa);
            var rsta = _mapper.Map<MesasDto>(mesa);
            return rsta;

        }

        public async Task<List<MesasDto>> GetAll()
        {
        List < Mesas > mesasList = await _mesaRepository.GetAll();
            var rsta = _mapper.Map<List<MesasDto>>(mesasList);
            return rsta;


        }

        public async Task<MesasDto> UpdateStatus(int idMesa, EstadosMesa estadoMesa)
        {
            if(estadoMesa == EstadosMesa.Cerrada)
            {
                throw new Exception("Accion no disponible con este metodo");
            }
            Mesas mesa = await _mesaRepository.GetById(idMesa);

            mesa.Estado = estadoMesa;
            await _mesaRepository.Edit(mesa);
            var rsta = _mapper.Map<MesasDto>(mesa);
            return rsta;
        }
    }
}
