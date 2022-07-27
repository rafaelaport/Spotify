using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class ExcluirAlbumCommand : IRequest<ExcluirAlbumCommandResponse>
    {
        public Guid Id { get; set; }

        public ExcluirAlbumCommand(Guid id)
        {
            Id = id;
        }
    }

    public class ExcluirAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public ExcluirAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }

}
