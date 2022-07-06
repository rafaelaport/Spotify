using Microsoft.AspNetCore.Mvc;
using Spotify.Domain.Account.Repository;

namespace Spotify.Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; }

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            UsuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("usuario/obter-todos")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.UsuarioRepository.GetAll());
        }
    }
}
