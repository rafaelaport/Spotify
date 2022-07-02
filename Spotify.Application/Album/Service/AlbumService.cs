using Spotify.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Service
{
    public class AlbumService
    {
        private readonly IAlbumRepository albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }
    }
}
