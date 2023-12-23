using Spotify.CrossCutting.Entity;
using Spotify.Domain.Streaming.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Agreggates
{
    public class Banda : Entity<Guid>
    {
        public string Nome { get; set; }
        public string CaminhoFoto { get; set; }
        public string Descricao { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();

        public void AdicionarAlbum(Album album) =>
            Albums.Add(album);
    }
}
