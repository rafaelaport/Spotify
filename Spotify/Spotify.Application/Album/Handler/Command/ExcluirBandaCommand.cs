using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class ExcluirBandaCommand : IRequest<ExcluirBandaCommandResponse>
    {
        public Guid Id { get; set; }

        public ExcluirBandaCommand(Guid id)
        {
            Id = id;
        }
    }

    public class ExcluirBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public ExcluirBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
