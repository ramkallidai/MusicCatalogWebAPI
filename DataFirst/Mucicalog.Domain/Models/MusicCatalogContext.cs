using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Musicalog.Domain.Models
{
    public partial class MusicCatalogContext : DbContext
    {
        public MusicCatalogContext()
        {
        }

        public MusicCatalogContext(DbContextOptions<MusicCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MusicCatalog;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
