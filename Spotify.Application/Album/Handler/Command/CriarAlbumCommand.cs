using MediatR;
using Spotify.Application.Album.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler.Command
{
    public class CriarAlbumCommand : IRequest<CriarAlbumCommandResponse>
    {

        public AlbumInputDto Album { get; set;}
        public Guid IdBanda { get; set;}

        public CriarAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }


    }

    public class CriarAlbumCommandResponse
    {

        public AlbumOutputDto Album {get; set;}

        public CriarAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }

    }
}
