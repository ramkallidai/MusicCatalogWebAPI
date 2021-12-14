using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Musicalog.Domain.Models;

namespace Musicalog.Api.EFCore.Interfaces
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task<IEnumerable<Album>> GetAllAlbumsByArtistAsync(Guid artist);
        Task<Album> GetAlbumByIdAsync(Guid albumId);
        Task CreateAlbumAsync(Album album);
        Task UpdateAlbumAsync(Album album);
        Task DeleteAlbumAsync(Album album);
    }
}
