using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class PlaylistFaixaMapping : IEntityTypeConfiguration<PlaylistFaixa>
    {
        public void Configure(EntityTypeBuilder<PlaylistFaixa> builder)
        {
            builder.ToTable("playlist_faixa");

            builder.Property<int>("playlist_id").IsRequired();

            builder.Property<int>("faixa_id").IsRequired();

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasKey("playlist_id", "faixa_id");

            builder.HasOne(pf => pf.Playlist)
                .WithMany(p => p.Faixas)
                .HasForeignKey("playlist_id");

            builder.HasOne(pf => pf.Faixa)
                .WithMany(f => f.Playlists)
                .HasForeignKey("faixa_id");
        }
    }
}
