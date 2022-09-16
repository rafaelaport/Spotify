using AutoMapper;
using Spotify.Application.Album.Dto;
using System.Net.Http;
using Spotify.Domain.Album.Repository;
using Spotify.Infrastructure.AzureBlobStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IMapper mapper;

        private IHttpClientFactory httpClientFactory;
        private AzureBlobStorage storage;

        public AlbumService(IAlbumRepository albumRepository, 
                            IMapper mapper, 
                            IHttpClientFactory httpClientFactory, 
                            AzureBlobStorage storage)
        {
            this.albumRepository = albumRepository;
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
            this.storage = storage;
        }

        public async Task<AlbumOutputDto> Criar(AlbumInputDto dto)
        {
            var album = this.mapper.Map<Spotify.Domain.Album.Album>(dto);

            HttpClient httpClient = this.httpClientFactory.CreateClient();

            using var response = await httpClient.GetAsync(album.CaminhoCapa);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();

                var fileName = $"{Guid.NewGuid()}.jpg";

                var pathStorage = await this.storage.UploadFile(fileName, stream);

                album.CaminhoCapa = pathStorage;

            }

            await this.albumRepository.Save(album);

            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<AlbumOutputDto> Editar(AlbumUpdateDto dto)
        {
            var album = this.mapper.Map<Spotify.Domain.Album.Album>(dto);
                        
            await this.albumRepository.Update(album);

            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<AlbumOutputDto> Excluir(Guid id)
        {
            var album = await this.albumRepository.Get(id);

            await this.albumRepository.Delete(album);

            return this.mapper.Map<AlbumOutputDto>(album);
        }

        public async Task<List<AlbumOutputDto>> ObterTodos()
        {
            var result = await this.albumRepository.GetAll();

            return this.mapper.Map<List<AlbumOutputDto>>(result);
        }

        public async Task<AlbumOutputDto> ObterPorId(Guid id)
        {
            var result = await this.albumRepository.Get(id);

            return this.mapper.Map<AlbumOutputDto>(result);
        }
    }
}
