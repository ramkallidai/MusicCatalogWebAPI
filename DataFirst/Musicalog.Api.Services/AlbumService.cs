using Musicalog.Api.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Musicalog.Domain.Models;
namespace Musicalog.Api.Services
{
    public class AlbumService : IAlbumService
    {
        readonly AlbumRepository albumRepository;
        public AlbumService(AlbumRepository repository)
        {
            albumRepository = repository;
        }

        public async Task CreateAlbumAsync(Album album)
        {
            await albumRepository.CreateAlbumAsync(album);
        }

        public async Task DeleteAlbumAsync(Album album)
        {
            await albumRepository.DeleteAlbumAsync(album);
        }

        public async Task<Album> GetAlbumByIdAsync(Guid albumId)
        {
            return await albumRepository.GetAlbumByIdAsync(albumId);
        }

        public List<Album> GetAlbums()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Album>> GetAlbumsAsync()
        {
           return await albumRepository.GetAllAlbumsAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            await albumRepository.UpdateAlbumAsync(album);
        }
    }
    public interface IAlbumService
    {
        List<Album> GetAlbums();
        Task<IEnumerable<Album>> GetAlbumsAsync();
        Task<Album> GetAlbumByIdAsync(Guid albumId);
        Task CreateAlbumAsync(Album album);
        Task UpdateAlbumAsync(Album album);
        Task DeleteAlbumAsync(Album album);

    }

}
