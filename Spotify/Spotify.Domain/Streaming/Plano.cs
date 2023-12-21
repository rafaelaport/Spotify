using Spotify.CrossCutting.Entity;
using Spotify.Domain.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming
{
    public class Plano : Entity<Guid>
    {
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public Monetario Valor { get; set; }
    }
}
