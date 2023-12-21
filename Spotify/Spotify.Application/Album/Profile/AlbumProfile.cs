using Spotify.Application.Album.Dto;
using Spotify.Domain.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Profile
{
    public class AlbumProfile: AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaOutputDto>()
                .ForMember(x => x.Duracao, f => f.MapFrom(m => m.Duracao.ValorFormatado()));

            CreateMap<MusicaInputDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<MusicaUpdateDto, Musica>()
                .ForPath(x => x.Duracao.Valor, f => f.MapFrom(m => m.Duracao));

            CreateMap<Spotify.Domain.Streaming.Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, Spotify.Domain.Streaming.Album>();

            CreateMap<AlbumUpdateDto, Spotify.Domain.Streaming.Album>();

            CreateMap<Banda, BandaOutputDto>();

            CreateMap<BandaInputDto, Banda>();

            CreateMap<BandaUpdateDto, Banda>();

        }
    }
}
