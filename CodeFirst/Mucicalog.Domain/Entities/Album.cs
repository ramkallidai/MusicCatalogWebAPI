using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Musicalog.Domain.Entities
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public StorageType StorageType { get; set; }
        public int Storage { get; set; }
    }
     
    public enum StorageType
    {
        vinyl = 1,
        CD =2
    }

}
