using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Service;

namespace Spotify.Api.Controllers
{
    [ApiController]
    public class BandaController : ControllerBase
    {
        private readonly IMediator mediator;

        public BandaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("banda/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await this.mediator.Send(new ObterTodosBandaQuery()));
        }

        [HttpPost]
        [Route("banda/criar")]
        public async Task<IActionResult> Criar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new CriarBandaCommand(dto));
            return Created($"{result.Banda.Id}", result.Banda);
        }
    }
}
