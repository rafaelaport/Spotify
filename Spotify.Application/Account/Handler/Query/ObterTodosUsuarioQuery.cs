using MediatR;
using Spotify.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler.Query
{
    public class ObterTodosUsuarioQuery: IRequest<ObterTodosUsuarioQueryResponse>
    {
    }

    public class ObterTodosUsuarioQueryResponse 
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public ObterTodosUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
