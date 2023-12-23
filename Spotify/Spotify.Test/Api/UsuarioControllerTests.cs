using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Spotify.Api.Controllers;
using Spotify.Application.Account.Dto;
using Spotify.Application.Account.Handler.Query;
using Spotify.Application.Account.Service;
using Spotify.Application.Album.Dto;
using Spotify.Domain.Account.Agreggates;
using Spotify.Domain.Account.Repository;
using Spotify.Domain.Account.ValueObject;
using Spotify.Domain.Streaming.Agreggates;
using Spotify.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Test.Api
{
    public class UsuarioControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodosUsuariosComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "Musica 1", Duracao = new Duracao(98) },
                new Musica(){ Nome = "Musica 2", Duracao = new Duracao(190) },
                new Musica(){ Nome = "Musica 3", Duracao = new Duracao(198) }
            };

            List<Playlist> playlist = new List<Playlist>() {
                new Playlist(){ Nome = "Playslist 1", Musicas = musicas }
            };

            List<Usuario> usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    Nome = "Usuario",
                    Email = new Email("usuario@gmail.com"),
                    Senha = new Password("123456"),
                    Playlists = playlist
                }
            };

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            List<PlaylistOutputDto> playlistOutputDto = new List<PlaylistOutputDto>() {
                new PlaylistOutputDto(Guid.NewGuid(), "Playslist 1", musicaOutputDto)
            };

            List<UsuarioOutputDto> usuarioOutputDto = new List<UsuarioOutputDto>()
            {
                new UsuarioOutputDto(Guid.NewGuid(), "Usuario", new Email("usuario96@gmail.com"), new Password("123456"), playlistOutputDto)
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(usuarios.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<UsuarioOutputDto>>(usuarios)).Returns(usuarioOutputDto);

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.ObterTodos();

            mockMediator.Setup(x => x.Send(It.IsAny<ObterTodosUsuarioQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterTodosUsuarioQueryResponse(result));

            var controller = new UsuarioController(mockMediator.Object);
            var resultController = controller.ObterTodos();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterTodosUsuarioQueryResponse;
            Assert.NotNull(response.Usuarios);

        }

        [Fact]
        public async Task DeveBuscarUsuarioPorIdComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IUsuarioRepository> mockRepository = new Mock<IUsuarioRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            var id = Guid.NewGuid();

            List<Musica> musicas = new List<Musica>()
            {
                new Musica(){ Nome = "Musica 1", Duracao = new Duracao(98) },
                new Musica(){ Nome = "Musica 2", Duracao = new Duracao(190) },
                new Musica(){ Nome = "Musica 3", Duracao = new Duracao(198) }
            };

            List<Playlist> playlist = new List<Playlist>() {
                new Playlist(){ Nome = "Playslist 1", Musicas = musicas }
            };

            Usuario usuario = new Usuario()
            {
                Nome = "Usuario",
                Email = new Email("usuario@gmail.com"),
                Senha = new Password("123456"),
                Playlists = playlist
            };

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            List<PlaylistOutputDto> playlistOutputDto = new List<PlaylistOutputDto>() {
                new PlaylistOutputDto(Guid.NewGuid(), "Playslist 1", musicaOutputDto)
            };

            UsuarioOutputDto usuarioOutputDto = new UsuarioOutputDto(id, "Usuario", new Email("usuario96@gmail.com"), new Password("123456"), playlistOutputDto);

            mockRepository.Setup(x => x.Get(id)).ReturnsAsync(usuario);
            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(usuarioOutputDto);

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.ObterPorId(id);

            mockMediator.Setup(x => x.Send(It.IsAny<ObterPorIdUsuarioQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterPorIdUsuarioQueryResponse(result));

            var controller = new UsuarioController(mockMediator.Object);
            var resultController = controller.ObterPorId(id);

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterPorIdUsuarioQueryResponse;
            Assert.NotNull(response.Usuario);

        }
    }
}
