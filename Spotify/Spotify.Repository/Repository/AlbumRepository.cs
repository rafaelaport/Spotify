using Microsoft.EntityFrameworkCore;
using Spotify.Domain.Streaming.Agreggates;
using Spotify.Domain.Streaming.Repository;
using Spotify.Repository.Context;
using Spotify.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Album>> ObterTodosAlbuns()
        {
            return await this.Query.Include(x => x.Musicas).ToListAsync();
        }
    }
}
