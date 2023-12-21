using Spotify.CrossCutting.Entity;
using Spotify.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account
{
    public class Assinatura : Entity<Guid>
    {
        public Plano Plano { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DtAtivacao { get; set; }
    }
}
