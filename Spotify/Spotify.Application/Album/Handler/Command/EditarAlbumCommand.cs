using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class EditarAlbumCommand : IRequest<EditarAlbumCommandResponse>
    {
        public AlbumUpdateDto Album { get; set; }

        public EditarAlbumCommand(AlbumUpdateDto album)
        {
            Album = album;
        }
    }

    public class EditarAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public EditarAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }

}
