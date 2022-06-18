using Spotify.CrossCutting.Entity;
using Spotify.Domain.Account;
using Spotify.Domain.Album.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album
{
    public class Musica: Entity<Guid>
    {
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

        public IList<Playlist> Playlists { get; set; }
    }
}
