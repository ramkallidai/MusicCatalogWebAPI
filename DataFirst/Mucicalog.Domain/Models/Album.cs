using Musicalog.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Musicalog.Domain.Models
{
    public partial class Album
    {
        public Guid AlbumId { get; set; }
        public string Title { get; set; }
        public Guid ArtistId { get; set; }
        public int? MediaType { get; set; }
        public int? Stock { get; set; }

        public Artist Artist { get; set; }
    }
}
