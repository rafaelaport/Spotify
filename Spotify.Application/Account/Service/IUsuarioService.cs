using Spotify.Application.Account.Dto;

namespace Spotify.Application.Account.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioOutputDto> Criar(UsuarioInputDto dto);
        Task<List<UsuarioOutputDto>> ObterTodos();
        Task<UsuarioOutputDto> ObterPorId(Guid id);
    }
}