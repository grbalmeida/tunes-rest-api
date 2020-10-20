using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class TipoMidiaMapping : IEntityTypeConfiguration<TipoMidia>
    {
        public void Configure(EntityTypeBuilder<TipoMidia> builder)
        {
            builder.ToTable("tipo_midia");

            builder.Property(tm => tm.TipoMidiaId)
                .HasColumnName("tipo_midia_id");

            builder.Property(tm => tm.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(120)")
                .IsRequired();

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
