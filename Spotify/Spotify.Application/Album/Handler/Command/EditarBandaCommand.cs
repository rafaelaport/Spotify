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
        public Guid Id { get; set; }
        public BandaInputDto Banda { get; set; }

        public EditarBandaCommand(Guid id, BandaInputDto banda)
        {
            Id = id;
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
