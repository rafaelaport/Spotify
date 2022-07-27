using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Query
{
    public class ObterTodosAlbumQuery : IRequest<ObterTodosAlbumQueryResponse>
    {
    }

    public class ObterTodosAlbumQueryResponse
    {
        public IList<AlbumOutputDto> Albums { get; set; }

        public ObterTodosAlbumQueryResponse(IList<AlbumOutputDto> albums)
        {
            Albums = albums;
        }

    }
}
