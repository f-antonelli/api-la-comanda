using AutoMapper;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Entities.Enums;
using Restaurante.Repository;
using Restaurante.Repository.Interfaces;
using Restaurante.Services.Interfaces;

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

            //throw new NotImplementedException();
        }

      
        public Task<MesasDto> UpdateStatus(int idMesa, EstadosMesa estadoMesa)
        {
            throw new NotImplementedException();
        }
    }
}
