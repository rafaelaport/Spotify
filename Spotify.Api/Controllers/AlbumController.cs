using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Handler.Query;
using Spotify.Domain.Album.Repository;

namespace Spotify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator mediator;

        public AlbumController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await this.mediator.Send(new ObterTodosAlbumQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await this.mediator.Send(new CriarAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

    }
}