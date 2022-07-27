using MediatR;
using Microsoft.AspNetCore.Mvc;
using Spotify.Application.Account.Dto;
using Spotify.Application.Account.Handler.Command;
using Spotify.Application.Account.Handler.Query;
using Spotify.Domain.Account.Repository;

namespace Spotify.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("usuario/obter-todos")]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await this.mediator.Send(new ObterTodosUsuarioQuery()));
        }

        [HttpGet]
        [Route("usuario/obter-por-id/{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await this.mediator.Send(new ObterPorIdUsuarioQuery(id)));
        }

        [HttpPost]
        [Route("usuario/criar")]
        public async Task<IActionResult> Criar(UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new CriarUsuarioCommand(dto));
            return Created($"{result.Usuario.Id}", result.Usuario);
        }

        [HttpPut]
        [Route("usuario/editar/{id}")]
        public async Task<IActionResult> Editar(Guid id, [FromBody] UsuarioInputDto dto)
        {
            var result = await this.mediator.Send(new EditarUsuarioCommand(id, dto));
            return Ok(result);
        }

        [HttpDelete]
        [Route("usuario/excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            var result = await this.mediator.Send(new ExcluirUsuarioCommand(id));
            return Ok(result);
        }
    }
}
