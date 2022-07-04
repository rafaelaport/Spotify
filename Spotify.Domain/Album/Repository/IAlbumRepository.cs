using Spotify.CrossCutting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album.Repository
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> ObterTodosAlbuns();
    }
}
