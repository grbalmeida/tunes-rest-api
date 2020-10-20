using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class ArtistaMapping : IEntityTypeConfiguration<Artista>
    {
        public void Configure(EntityTypeBuilder<Artista> builder)
        {
            builder.ToTable("artista");

            builder.Property(a => a.ArtistaId)
                .HasColumnName("artista_id");

            builder.Property(a => a.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
