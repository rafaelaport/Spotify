using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Query
{
    public class ObterPorIdBandaQuery : IRequest<ObterPorIdBandaQueryResponse>
    {
        public Guid Id { get; set; }

        public ObterPorIdBandaQuery(Guid id)
        {
            Id = id;
        }
    }

    public class ObterPorIdBandaQueryResponse
    {
        public BandaOutputDto Banda { get; set; }

        public ObterPorIdBandaQueryResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }

    }
}
