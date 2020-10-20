using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("album");

            builder.Property(a => a.AlbumId)
                .HasColumnName("album_id");

            builder.Property(a => a.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(160)")
                .IsRequired();

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property<int>("artista_id");

            builder.HasOne(a => a.Artista)
                .WithMany(a => a.Albuns)
                .HasForeignKey("artista_id");
        }
    }
}
