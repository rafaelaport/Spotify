using Spotify.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming
{
    public class Album: Entity<Guid>
    {
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string CaminhoCapa { get; set; }

        public List<Musica> Musicas { get; set; } = new List<Musica>();

        public void AdicionarMusica(Musica musica) =>
            this.Musicas.Add(musica);

        public void AdicionarMusica(List<Musica> musica) =>
            this.Musicas.AddRange(musica);
    }
}
