using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Musicalog.Domain.Entities;

namespace Musicalog.Api.EFCore.Interfaces
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task<Album> GetAlbumByIdAsync(int albumId);
        Task CreateAlbumAsync(Album album);
        Task UpdateAlbumAsync(Album album);
        Task DeleteAlbumAsync(Album album);
    }
}
