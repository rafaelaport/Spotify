using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Spotify.Api.Controllers;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Service;
using Spotify.Domain.Streaming;
using Spotify.Domain.Streaming.Repository;
using Spotify.Domain.Streaming.ValueObject;

namespace Spotify.Test.Api
{
    public class AlbumControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodosAlbunsComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IAlbumRepository> mockRepository = new Mock<IAlbumRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            List<AlbumOutputDto> albumOutputDto = new List<AlbumOutputDto>() {
                new AlbumOutputDto(Guid.NewGuid(), "Album Teste", DateTime.Now, "https://xpto.com/capa.png", musicaOutputDto)
            };

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "Musica 1", Duracao = new Duracao(98) },
                new Musica(){ Nome = "Musica 2", Duracao = new Duracao(190) },
                new Musica(){ Nome = "Musica 3", Duracao = new Duracao(198) }
            };

            List<Album> album = new List<Album>()
            {
                new Album()
                {
                    Nome = "Album Teste",
                    DataLancamento = DateTime.Now,
                    CaminhoCapa = "https://xpto.com/capa.png",
                    Musicas = musicas
                }
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(album.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<AlbumOutputDto>>(album)).Returns(albumOutputDto);

            //var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            //var result = await service.ObterTodos();

           // mockMediator.Setup(x => x.Send(It.IsAny<ObterTodosAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterTodosAlbumQueryResponse(result));

            var controller = new AlbumController(mockMediator.Object);
            var resultController = controller.ObterTodos();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterTodosAlbumQueryResponse;
            Assert.NotNull(response.Albums);

        }

        [Fact]
        public async Task DeveBuscarALbumPorIdComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IAlbumRepository> mockRepository = new Mock<IAlbumRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            var id = Guid.NewGuid();

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            AlbumOutputDto albumOutputDto = new AlbumOutputDto(id, "Album Teste", DateTime.Now, "https://xpto.com/capa.png", musicaOutputDto);

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

            

            mockRepository.Setup(x => x.Get(id)).ReturnsAsync(album);
            mockMapper.Setup(x => x.Map<AlbumOutputDto>(album)).Returns(albumOutputDto);

            //var service = new AlbumService(mockRepository.Object, mockMapper.Object);
            //var result = await service.ObterPorId(id);

            //mockMediator.Setup(x => x.Send(It.IsAny<ObterPorIdAlbumQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterPorIdAlbumQueryResponse(result));

            var controller = new AlbumController(mockMediator.Object);
            var resultController = controller.ObterPorId(id);

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterPorIdAlbumQueryResponse;
            Assert.NotNull(response.Album);

        }
    }
}
