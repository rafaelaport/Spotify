using Spotify.CrossCutting.Entity;
using Spotify.Domain.Streaming.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account.Agreggates
{
    public class Assinatura : Entity<Guid>
    {
        public Plano Plano { get; set; }
        public bool Ativo { get; set; }
        public DateTime DtAtivacao { get; set; }
    }
}
