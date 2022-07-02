using Spotify.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album
{
    public class Album: Entity<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string CaminhoCapa { get; set; }
        public IList<Musica> Musicas { get; set; }
    }
}
