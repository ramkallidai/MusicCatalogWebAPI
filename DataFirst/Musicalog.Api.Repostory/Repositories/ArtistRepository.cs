using Microsoft.EntityFrameworkCore;
using Musicalog.Domain.Models;
using Musicalog.Api.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Musicalog.Api.EFCore.Repositories
{
    public class ArtistRepository : GenericRepository<Domain.Models.Artist>, IArtistRepository
    {
        public ArtistRepository(MusicCatalogContext context) : base(context)
        {

        }
        public void Create(Artist artist)
        {
           
        }

        public async Task CreateArtistAsync(Artist artist)
        {
            Create(artist);
            await SaveAsync();
        }

        public void Delete(Artist entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteArtistAsync(Artist artist)
        {
            Delete(artist);
            await SaveAsync();
        }

 

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await FindAll().OrderBy(o => o.ArtistName ).ToListAsync();
        }

        public Task<Artist> GetArtistByIdAsync(Guid ArtistId)
        {
            throw new NotImplementedException();
        }

        public void Update(Artist entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateArtistAsync(Artist Artist)
        {
            throw new NotImplementedException();
        }

        IQueryable<Artist> IGenericRepository<Artist>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
