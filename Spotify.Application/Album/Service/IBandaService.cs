using Spotify.Application.Album.Dto;

namespace Spotify.Application.Album.Service
{
    public interface IBandaService
    {
        Task<BandaOutputDto> Criar(BandaInputDto dto);
        Task<List<BandaOutputDto>> ObterTodos();
    }
}