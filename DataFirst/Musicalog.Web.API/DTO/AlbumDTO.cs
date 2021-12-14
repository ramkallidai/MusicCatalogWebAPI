using Musicalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.Web.API.DTO
{
    public class AlbumDTO
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public Guid ArtistId { get; set; }
        public int MediaType { get; set; }
        public int Stock { get; set; }
        public Artist Artist { get; set; }
    }
}
