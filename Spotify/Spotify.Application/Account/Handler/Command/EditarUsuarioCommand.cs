using MediatR;
using Spotify.Application.Account.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Handler.Command
{
    public class EditarUsuarioCommand : IRequest<EditarUsuarioCommandResponse>
    {
        public UsuarioUpdateDto Usuario { get; set; }

        public EditarUsuarioCommand(UsuarioUpdateDto usuario)
        {
            Usuario = usuario;
        }
    }

    public class EditarUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public EditarUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
