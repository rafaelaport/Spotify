using Spotify.CrossCutting.Repository;
using Spotify.Domain.Account.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
    }
}
