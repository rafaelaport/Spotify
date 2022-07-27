using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class CriarBandaCommand : IRequest<CriarBandaCommandResponse>
    {
        public BandaInputDto Banda { get; set; }

        public CriarBandaCommand(BandaInputDto banda)
        {
            Banda = banda;
        }
    }

    public class CriarBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public CriarBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }

}
