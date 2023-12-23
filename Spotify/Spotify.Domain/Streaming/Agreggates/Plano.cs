using Spotify.CrossCutting.Entity;
using Spotify.Domain.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.Agreggates
{
    public class Plano : Entity<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Monetario Valor { get; set; }
    }
}
