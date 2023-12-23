using AutoMapper;
using Moq;
using Spotify.Application.Account.Dto;
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

namespace Spotify.Test.Application
{
    public class UsuarioServiceTests
    {
        [Fact]
        public async Task DeveCriarUsuarioComSucesso()
        {
            List<MusicaInputDto> musicaInputDto = new List<MusicaInputDto>(){
                new MusicaInputDto("Musica 1", 98),
                new MusicaInputDto("Musica 2", 190),
                new MusicaInputDto("Musica 3", 198)
            };

            List<PlaylistInputDto> playlistInputDto = new List<PlaylistInputDto>() {
                new PlaylistInputDto("Playslist 1", musicaInputDto)
            };

            UsuarioInputDto usuarioInputDto = new UsuarioInputDto("Usuario", new Email("usuario96@gmail.com"), new Password("123456"), playlistInputDto);

            List<MusicaOutputDto> musicaOutputDto = new List<MusicaOutputDto>(){
                new MusicaOutputDto(Guid.NewGuid(), "Musica 1", "98"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 2", "190"),
                new MusicaOutputDto(Guid.NewGuid(), "Musica 3", "198")
            };

            List<PlaylistOutputDto> playlistOutputDto = new List<PlaylistOutputDto>() {
                new PlaylistOutputDto(Guid.NewGuid(), "Playslist 1", musicaOutputDto)
            };

            UsuarioOutputDto usuarioOutputDto = new UsuarioOutputDto(Guid.NewGuid(), "Usuario", new Email("usuario96@gmail.com"), new Password("123456"), playlistOutputDto);

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

            Usuario usuario = new Usuario()
            {
                Nome = "Usuario",
                Email = new Email("usuario@gmail.com"),
                Senha = new Password("A123456@"),
                Playlists = playlist
            };
            
            mockMapper.Setup(x => x.Map<Usuario>(usuarioInputDto)).Returns(usuario);
            mockRepository.Setup(x => x.Save(It.IsAny<Usuario>())).Returns(Task.FromResult(usuario));
            mockMapper.Setup(x => x.Map<UsuarioOutputDto>(usuario)).Returns(usuarioOutputDto);

            var service = new UsuarioService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(usuarioInputDto);

            Assert.NotNull(result);


        }
    }
}
