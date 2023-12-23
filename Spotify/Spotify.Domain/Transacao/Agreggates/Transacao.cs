using Spotify.CrossCutting.Entity;
using Spotify.Domain.Core.ValueObject;
using Spotify.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Transacao.Agreggates
{
    public class Transacao : Entity<Guid>
    {
        public DateTime DtTransacao { get; set; }
        public Monetario Valor { get; set; }
        public string Descricao { get; set; }
        public Merchant Merchant { get; set; }

    }
}
