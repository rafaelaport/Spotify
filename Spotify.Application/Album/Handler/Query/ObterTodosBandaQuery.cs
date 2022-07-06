using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Query
{
    public class ObterTodosBandaQuery: IRequest<ObterTodosBandaQueryResponse>
    {
    }

    public class ObterTodosBandaQueryResponse
    {

        public IList<BandaOutputDto> Bandas {get; set;}

        public ObterTodosBandaQueryResponse(IList<BandaOutputDto> bandas)
        {
            this.Bandas = bandas;
        }
    }

}
