using Spotify.CrossCutting.Entity;
using Spotify.Domain.Album.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album
{
    public class Banda: Entity<Guid>
    {
        public string Nome { get; set; }
        public string CaminhoFoto { get; set; }
        public string Descricao { get; set; }
        public virtual IList<Album> Albuns { get; set; }

        public void CriarAlbum(string nome, IList<Musica> musicas)
        {
            var album = AlbumFactory.Criar(nome, musicas);
            this.Albuns.Add(album);
        }

        public int QuantidadeAlbuns() => this.Albuns.Count;

        public IEnumerable<Musica> ObterMusicas() => this.Albuns.SelectMany(a => a.Musicas).AsEnumerable();
    }
}
