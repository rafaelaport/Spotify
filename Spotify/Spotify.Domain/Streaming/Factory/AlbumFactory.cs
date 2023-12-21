using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Factory
{
    public static class AlbumFactory
    {

        public static Album Criar(string nome, Musica musica)
        {
            if (musica == null)
            {
                throw new ArgumentNullException("Para criar um álbum, o álbum deve ter no mínimo uma música");
            }

            return new Album()
            {
                Musicas = new List<Musica>() { musica }
            };
        }

        public static Album Criar(string nome, IEnumerable<Musica> musicas)
        {
            if (musicas.Any())
            {
                throw new ArgumentNullException("Para criar um álbum, o álbum deve ter no mínimo uma música");
            }

            return new Album()
            {
                Musicas = musicas.ToList()
            };
        }
    }
}
