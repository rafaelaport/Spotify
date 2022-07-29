using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Handler.Query;
using Spotify.Domain.Album.Repository;

namespace Spotify.Api.Controllers
{
    
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlbumController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("album/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await this.mediator.Send(new ObterTodosAlbumQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("album/obter-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var result = await this.mediator.Send(new ObterPorIdAlbumQuery(id));
            return Ok(result);
        }

        [HttpPost]
        [Route("album/criar")]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CriarAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpPut]
        [Route("album/editar")]
        public async Task<IActionResult> Editar([FromBody] AlbumUpdateDto dto)
        {
            var result = await this.mediator.Send(new EditarAlbumCommand(dto));
            return Ok(result);
        }

        [HttpDelete]
        [Route("album/excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await this.mediator.Send(new ExcluirAlbumCommand(id));
            return Ok(result);
        }
    }
}