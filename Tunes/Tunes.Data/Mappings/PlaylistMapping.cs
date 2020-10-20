using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable("playlist");

            builder.Property(p => p.PlaylistId)
                .HasColumnName("playlist_id");

            builder.Property(p => p.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
