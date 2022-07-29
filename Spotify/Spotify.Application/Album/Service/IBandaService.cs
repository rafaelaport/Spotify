using Spotify.Application.Album.Dto;

namespace Spotify.Application.Album.Service
{
    public interface IBandaService
    {
        Task<BandaOutputDto> Criar(BandaInputDto dto);
        Task<BandaOutputDto> Editar(BandaUpdateDto dto);
        Task<BandaOutputDto> Excluir(Guid id);
        Task<List<BandaOutputDto>> ObterTodos();
        Task<BandaOutputDto> ObterPorId(Guid id);
    }
}