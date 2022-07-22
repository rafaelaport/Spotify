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
            var temp = await this.mediator.Send(new ObterTodosAlbumQuery());
            return Ok(temp);
        }

        [HttpGet]
        [Route("album/obter-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var temp = await this.mediator.Send(new ObterPorIdAlbumQuery(id));
            return Ok(temp);
        }

        [HttpPost]
        [Route("album/criar")]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CriarAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

    }
}