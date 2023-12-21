using AutoMapper;
using Spotify.Application.Album.Dto;
using Spotify.Domain.Streaming;
using Spotify.Domain.Streaming.Repository;
using Spotify.Infrastructure.AzureBlobStorage;
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

        private IHttpClientFactory httpClientFactory;
        private AzureBlobStorage storage;

        public BandaService(IBandaRepository bandaRepository, 
                            IMapper mapper, 
                            AzureBlobStorage storage,
                            IHttpClientFactory httpClientFactory)
        {
            this.bandaRepository = bandaRepository;
            this.mapper = mapper;
            this.storage = storage;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<BandaOutputDto> Criar(BandaInputDto dto)
        {
            var banda = this.mapper.Map<Banda>(dto);

            HttpClient httpClient = this.httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(banda.CaminhoFoto);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await this.storage.UploadFile(fileName, stream);

                banda.CaminhoFoto = pathStorage;

            }

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
