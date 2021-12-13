using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Musicalog.Domain.Models;

namespace Musicalog.Api.EFCore
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
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MusicCatalog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId)
                    .HasColumnName("AlbumID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Artist).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);
            });

        }
    }
}
