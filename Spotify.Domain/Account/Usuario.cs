using FluentValidation;
using Spotify.CrossCutting.Entity;
using Spotify.CrossCutting.Utils;
using Spotify.Domain.Account.Rules;
using Spotify.Domain.Account.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account
{
    public class Usuario: Entity<Guid>
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Password Senha { get; set; }
        public virtual IList<Playlist> Playlists {get; set;}

        public void SetPassword()
        {
            this.Senha.Valor = SecurityUtils.HashSHA1(this.Senha.Valor);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);
    }
}
