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
        public Guid Id { get; set; }
        public AlbumInputDto Album { get; set; }

        public EditarAlbumCommand(Guid id, AlbumInputDto album)
        {
            Id = id;
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
