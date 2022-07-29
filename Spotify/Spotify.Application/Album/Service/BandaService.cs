using AutoMapper;
using Spotify.Application.Album.Dto;
using Spotify.Domain.Album;
using Spotify.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Service
{
    public class BandaService : IBandaService
    {
        private readonly IBandaRepository bandaRepository;
        private readonly IMapper mapper;

        public BandaService(IBandaRepository bandaRepository, IMapper mapper)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
        }

        public async Task<BandaOutputDto> Criar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);
           
            await this.bandaRepository.Save(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> Editar(BandaUpdateDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);

            await this.bandaRepository.Update(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<BandaOutputDto> Excluir(Guid id)
        {
            var banda = await this.bandaRepository.Get(id);

            await this.bandaRepository.Delete(banda);

            return this.mapper.Map<BandaOutputDto>(banda);
        }

        public async Task<List<BandaOutputDto>> ObterTodos()
        {
            var result = await this.bandaRepository.GetAll();

            return this.mapper.Map<List<BandaOutputDto>>(result);
        }

        public async Task<BandaOutputDto> ObterPorId(Guid id)
        {
            var result = await this.bandaRepository.Get(id);

            return this.mapper.Map<BandaOutputDto>(result);
        }
    }
}
