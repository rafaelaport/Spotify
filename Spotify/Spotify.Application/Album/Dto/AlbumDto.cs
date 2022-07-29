using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Dto
{
    public record AlbumInputDto(string Nome, DateTime DataLancamento, string CaminhoCapa, List<MusicaInputDto> Musicas);
    public record AlbumUpdateDto(Guid Id, string Nome, DateTime DataLancamento, string CaminhoCapa, List<MusicaUpdateDto> Musicas);
    public record AlbumOutputDto(Guid Id, string Nome, DateTime DataLancamento, string CaminhoCapa, List<MusicaOutputDto> Musicas);
    public record MusicaInputDto(string Nome, int Duracao);
    public record MusicaUpdateDto(Guid Id, string Nome, int Duracao);
    public record MusicaOutputDto(Guid Id, string Nome, string Duracao);
    public record BandaInputDto(
        [Required(ErrorMessage = "Nome é obrigatório!")] string Nome, 
        [Required(ErrorMessage = "Foto é obrigatório!")] string CaminhoFoto,
        [Required(ErrorMessage = "Descrição é obrigatório!")] string Descricao);
    public record BandaUpdateDto(
        Guid Id,
        [Required(ErrorMessage = "Nome é obrigatório!")] string Nome,
        [Required(ErrorMessage = "Foto é obrigatório!")] string CaminhoFoto,
        [Required(ErrorMessage = "Descrição é obrigatório!")] string Descricao);
    public record BandaOutputDto(Guid Id, string Nome, string CaminhoFoto, string Descricao);
}
