using AutoMapper;
using Moq;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Service;
using Spotify.Domain.Account;
using Spotify.Domain.Streaming;
using Spotify.Domain.Streaming.Repository;
using Spotify.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Test.Application
{
    public class AlbumServiceTests
    {
        [Fact]
        public async Task DeveCriarAlbumComSucesso()
        {
            List<MusicaInputDto> musicaInputDto = new List<MusicaInputDto>(){
                new MusicaInputDto("Musica 1", 98),
                new MusicaInputDto("Musica 2", 190),
                new MusicaInputDto("Musica 3", 198)
            };

            AlbumInputDto albumInputDto = new AlbumInputDto("Album Teste", DateTime.Now, "https://xpto.com/capa.png", musicaInputDto);

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            AlbumOutputDto albumOutputDto = new AlbumOutputDto(Guid.NewGuid(), "Album Teste", DateTime.Now, "https://xpto.com/capa.png", musicaOutputDto);

            Mock<IAlbumRepository> mockRepository = new Mock<IAlbumRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "Musica 1", Duracao = new Duracao(98) },
                new Musica(){ Nome = "Musica 2", Duracao = new Duracao(190) },
                new Musica(){ Nome = "Musica 3", Duracao = new Duracao(198) }
            };

            Album album = new Album()
            {
                Nome = "Album Teste",
                DataLancamento = DateTime.Now,
                CaminhoCapa = "https://xpto.com/capa.png",
                Musicas = musicas
            };

            mockMapper.Setup(x => x.Map<Album>(albumInputDto)).Returns(album);
            mockRepository.Setup(x => x.Save(It.IsAny<Album>())).Returns(Task.FromResult(album));
            mockMapper.Setup(x => x.Map<AlbumOutputDto>(album)).Returns(albumOutputDto);

            //var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            //var result = await service.Criar(albumInputDto);

            //Assert.NotNull(result);
        }
    }
}
