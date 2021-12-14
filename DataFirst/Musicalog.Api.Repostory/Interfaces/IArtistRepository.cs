using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Musicalog.Domain.Models;

namespace Musicalog.Api.EFCore.Interfaces
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist> GetArtistByIdAsync(Guid ArtistId);
        Task CreateArtistAsync(Artist Artist);
        Task UpdateArtistAsync(Artist Artist);
        Task DeleteArtistAsync(Artist Artist);
    }
}
