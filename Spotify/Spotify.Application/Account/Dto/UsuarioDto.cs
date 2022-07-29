using Spotify.Application.Album.Dto;
using Spotify.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Dto
{
    public record UsuarioInputDto(string Nome, Email Email, Password Senha, List<PlaylistInputDto> Playlists);
    public record UsuarioUpdateDto(Guid Id, string Nome, Email Email, Password Senha, List<PlaylistUpdateDto> Playlists);
    public record UsuarioOutputDto(Guid Id, string Nome, Email Email, Password Senha, List<PlaylistOutputDto> Playlists);
    public record PlaylistInputDto(string Nome, List<MusicaInputDto> Musicas);
    public record PlaylistUpdateDto(Guid Id, string Nome, List<MusicaUpdateDto> Musicas);
    public record PlaylistOutputDto(Guid Id, string Nome, List<MusicaOutputDto> Musicas);
}
