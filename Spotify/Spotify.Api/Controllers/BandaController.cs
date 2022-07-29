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

        [HttpGet]
        [Route("banda/obter-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new ObterPorIdBandaQuery(id)));
        }

        [HttpPost]
        [Route("banda/criar")]
        public async Task<IActionResult> Criar(BandaInputDto dto)
        {
            var result = await this.mediator.Send(new CriarBandaCommand(dto));
            return Created($"{result.Banda.Id}", result.Banda);
        }

        [HttpPut]
        [Route("banda/editar")]
        public async Task<IActionResult> Editar([FromBody] BandaUpdateDto dto)
        {
            var result = await this.mediator.Send(new EditarBandaCommand(dto));
            return Ok(result);
        }

        [HttpDelete]
        [Route("banda/excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await this.mediator.Send(new ExcluirBandaCommand(id));
            return Ok(result);
        }
    }
}
