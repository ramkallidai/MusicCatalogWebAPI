using System;
using System.Collections.Generic;

namespace Musicalog.Web.API.Models
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public Guid ArtistId { get; set; }
        public string ArtistName { get; set; }

        public ICollection<Album> Album { get; set; }
    }
}
