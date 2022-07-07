using MediatR;
using Spotify.Application.Account.Handler.Command;
using Spotify.Application.Account.Handler.Query;
using Spotify.Application.Account.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler
{
    public class UsuarioHandler : IRequestHandler<CriarUsuarioCommand, CriarUsuarioCommandResponse>,
                                  IRequestHandler<ObterTodosUsuarioQuery, ObterTodosUsuarioQueryResponse>
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public async Task<CriarUsuarioCommandResponse> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await usuarioService.Criar(request.Usuario);

            return new CriarUsuarioCommandResponse(result);
        }

        public async Task<ObterTodosUsuarioQueryResponse> Handle(ObterTodosUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await usuarioService.ObterTodos();

            return new ObterTodosUsuarioQueryResponse(result);
        }
    }
}
