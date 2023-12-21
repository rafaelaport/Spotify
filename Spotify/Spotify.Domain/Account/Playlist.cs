using Spotify.CrossCutting.Entity;
using Spotify.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account
{
    public class Playlist: Entity<Guid>
    {
        public string Nome { get; set; }
        public Boolean Publica { get; set; }
        public Usuario Usuario { get; set; }
        public List<Musica> Musicas { get; set; }
        public DateTime DtCriacao { get; set; }

    }
}
