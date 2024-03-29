﻿using Spotify.Application.Account.Dto;
using Spotify.Domain.Account.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Account.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioOutputDto>();
            CreateMap<UsuarioInputDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            CreateMap<Playlist, PlaylistOutputDto>();
            CreateMap<PlaylistInputDto, Playlist>();
            CreateMap<PlaylistUpdateDto, Playlist>();
        }
    }
}
