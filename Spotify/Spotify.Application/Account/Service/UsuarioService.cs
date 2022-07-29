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

            usuario.Validate();
            usuario.SetPassword();

            await usuarioRepository.Save(usuario);

            return mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Editar(UsuarioUpdateDto dto)
        {
            var usuario = this.mapper.Map<Usuario>(dto);

            usuario.Validate();
            usuario.SetPassword();

            await this.usuarioRepository.Update(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<UsuarioOutputDto> Excluir(Guid id)
        {
            var usuario = await this.usuarioRepository.Get(id);

            await this.usuarioRepository.Delete(usuario);

            return this.mapper.Map<UsuarioOutputDto>(usuario);
        }

        public async Task<List<UsuarioOutputDto>> ObterTodos()
        {
            var result = await usuarioRepository.GetAll();

            return mapper.Map<List<UsuarioOutputDto>>(result);
        }

        public async Task<UsuarioOutputDto> ObterPorId(Guid id)
        {
            var result = await usuarioRepository.Get(id);

            return mapper.Map<UsuarioOutputDto>(result);
        }

    }
}
