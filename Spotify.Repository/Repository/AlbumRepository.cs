using Spotify.Domain.Album;
using Spotify.Repository.Context;
using Spotify.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Repository
{
    public class AlbumRepository : Repository<Album>
    {
        public AlbumRepository(SpotifyContext context) : base(context)
        {

        }
    }
}
