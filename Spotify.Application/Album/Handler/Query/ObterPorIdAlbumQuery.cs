using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Query
{
    public class ObterPorIdAlbumQuery : IRequest<ObterPorIdAlbumQueryResponse>
    {
        public Guid Id { get; set; }

        public ObterPorIdAlbumQuery(Guid id)
        {
            Id = id;
        }
    }

    public class ObterPorIdAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public ObterPorIdAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }

    }
}
