﻿using Spotify.Application.Album.Dto;

namespace Spotify.Application.Album.Service
{
    public interface IAlbumService
    {
        Task<AlbumOutputDto> Criar(AlbumInputDto dto);
        Task<AlbumOutputDto> Editar(AlbumUpdateDto dto);
        Task<AlbumOutputDto> Excluir(Guid id);
        Task<List<AlbumOutputDto>> ObterTodos();
        Task<AlbumOutputDto> ObterPorId(Guid id);
    }
}