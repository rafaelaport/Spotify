using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class EditarBandaCommand : IRequest<EditarBandaCommandResponse>
    {
        public BandaUpdateDto Banda { get; set; }

        public EditarBandaCommand(BandaUpdateDto banda)
        {
            Banda = banda;
        }
    }

    public class EditarBandaCommandResponse
    {
        public BandaOutputDto Banda { get; set; }

        public EditarBandaCommandResponse(BandaOutputDto banda)
        {
            Banda = banda;
        }
    }
}
