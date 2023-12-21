using Spotify.CrossCutting.Entity;
using Spotify.Domain.Account;
using Spotify.Domain.Streaming.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming
{
    public class Musica: Entity<Guid>
    {
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    }
}
