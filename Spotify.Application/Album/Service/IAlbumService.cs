using Spotify.Application.Album.Dto;

namespace Spotify.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Criar(AlbumInputDto dto);
        Task<List<AlbumOutputDto>> ObterTodos();
    }
}