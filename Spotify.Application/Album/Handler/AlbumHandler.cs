using MediatR;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler
{
    public class AlbumHandler : IRequestHandler<CriarAlbumCommand, CriarAlbumCommandResponse>,
                                IRequestHandler<ObterTodosAlbumQuery, ObterTodosAlbumQueryResponse>,
                                IRequestHandler<ObterPorIdAlbumQuery, ObterPorIdAlbumQueryResponse>
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

        public async Task<ObterTodosAlbumQueryResponse> Handle(ObterTodosAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ObterTodos();
            return new ObterTodosAlbumQueryResponse(result);
        }

        public async Task<ObterPorIdAlbumQueryResponse> Handle(ObterPorIdAlbumQuery request, CancellationToken cancellationToken)
        {
            var result = await this._albumService.ObterPorId(request.Id);
            return new ObterPorIdAlbumQueryResponse(result);
        }
    }
}
