using MediatR;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler
{
    public class AlbumHandler : IRequestHandler<CriarAlbumCommand, CriarAlbumCommandResponse>
    {
        private readonly IAlbumService _albumService;

        public AlbumHandler(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<CriarAlbumCommandResponse> Handle(CriarAlbumCommand request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.Criar(request.Album);

            return new CriarAlbumCommandResponse(result);
        }
    }
}
