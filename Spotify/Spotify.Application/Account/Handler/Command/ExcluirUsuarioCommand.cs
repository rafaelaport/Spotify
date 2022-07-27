using MediatR;
using Spotify.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler.Command
{
    public class ExcluirUsuarioCommand : IRequest<ExcluirUsuarioCommandResponse>
    {
        public Guid Id { get; set; }

        public ExcluirUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }

    public class ExcluirUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public ExcluirUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
