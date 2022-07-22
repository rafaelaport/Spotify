using MediatR;
using Spotify.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler.Query
{
    public class ObterPorIdUsuarioQuery : IRequest<ObterPorIdUsuarioQueryResponse>
    {
        public Guid Id { get; set; }

        public ObterPorIdUsuarioQuery(Guid id)
        {
            Id = id;
        }
    }

    public class ObterPorIdUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public ObterPorIdUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }

    }
}
