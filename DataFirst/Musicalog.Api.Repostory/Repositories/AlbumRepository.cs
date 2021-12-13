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
    public class AlbumRepository : GenericRepository<Domain.Models.Album>, IAlbumRepository
    {
        public AlbumRepository(MusicCatalogContext context) : base(context)
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

        

       

        public async Task<Album> GetAlbumByIdAsync(Guid albumId)
        {
            return await FindByCondition(a => a.AlbumId.Equals(albumId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain.Models.Album>> GetAllAlbumsAsync()
        {
            return await FindAll().OrderBy(o => o.Title).ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsByArtistAsync(string artist)
        {
            return await FindAll().Where(a=>a.Artist== artist).OrderBy(o => o.Title).ToListAsync();
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            Update(album);
            await SaveAsync();
        }

    }
}
