using Microsoft.EntityFrameworkCore;
using Musicalog.Domain.Entities;
using Musicalog.Api.EFCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musicalog.Api.EFCore.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
            
        }
        public async Task CreateAlbumAsync(Album album)
        {
            Create(album);
            await SaveAsync();
        }

        public async Task DeleteAlbumAsync(Album album)
        {
            Delete(album);
            await SaveAsync();
        }

        public async Task<Album> GetAlbumByIdAsync(int albumId)
        {
            return await FindByCondition(a => a.AlbumID.Equals(albumId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return await FindAll().OrderBy(ow => ow.AlbumName).ToListAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            Update(album);
            await SaveAsync();
        }
    }
}
