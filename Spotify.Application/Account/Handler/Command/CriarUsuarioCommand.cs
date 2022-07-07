using MediatR;
using Spotify.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler.Command
{
    public class CriarUsuarioCommand: IRequest<CriarUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public CriarUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class CriarUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public CriarUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
