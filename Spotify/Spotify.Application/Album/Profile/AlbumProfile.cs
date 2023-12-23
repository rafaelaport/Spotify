using Spotify.Application.Album.Dto;
using Spotify.Domain.Streaming.Agreggates;
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

            CreateMap<Domain.Streaming.Agreggates.Album, AlbumOutputDto>();

            CreateMap<AlbumInputDto, Domain.Streaming.Agreggates.Album>();

            CreateMap<AlbumUpdateDto, Domain.Streaming.Agreggates.Album>();

            CreateMap<Banda, BandaOutputDto>();

            CreateMap<BandaInputDto, Banda>();

            CreateMap<BandaUpdateDto, Banda>();

        }
    }
}
