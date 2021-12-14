using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog.Domain.Models
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
