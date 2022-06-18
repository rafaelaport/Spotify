using Microsoft.AspNetCore.Mvc;
using Spotify.Domain.Album.Repository;

namespace Spotify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        public IAlbumRepository AlbumRepository { get; }

        public AlbumController(IAlbumRepository albumRepository)
        {
            AlbumRepository = albumRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.AlbumRepository.GetAll());
        }

    }
}