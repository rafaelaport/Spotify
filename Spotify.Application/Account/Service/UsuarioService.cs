using AutoMapper;
using Spotify.Application.Account.Dto;
using Spotify.Domain.Account;
using Spotify.Domain.Account.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Service
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository usuarioRepository;
        IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public async Task<UsuarioOutputDto> Criar(UsuarioInputDto dto)
        {
            var usuario = mapper.Map<Usuario>(dto);

            await usuarioRepository.Save(usuario);

            return mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var result = await usuarioRepository.GetAll();

            return mapper.Map<List<UsuarioOutputDto>>(result);
        }

    }
}
