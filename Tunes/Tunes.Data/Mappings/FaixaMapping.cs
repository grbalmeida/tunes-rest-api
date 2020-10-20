using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class FaixaMapping : IEntityTypeConfiguration<Faixa>
    {
        public void Configure(EntityTypeBuilder<Faixa> builder)
        {
            builder.ToTable("faixa");

            builder.Property(f => f.FaixaId)
                .HasColumnName("faixa_id");

            builder.Property(f => f.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property<int?>("album_id");

            builder.Property<int>("tipo_midia_id");

            builder.Property<int?>("genero_id");

            builder.Property(f => f.Compositor)
                .HasColumnName("compositor")
                .HasColumnType("varchar(220)");

            builder.Property(f => f.Milissegundos)
                .HasColumnName("milissegundos");

            builder.Property(f => f.Bytes)
                .HasColumnName("bytes");

            builder.Property(f => f.PrecoUnitario)
                .HasColumnName("preco_unitario")
                .HasColumnType("numeric(10, 2)");

            builder.HasOne(f => f.Album)
                .WithMany(a => a.Faixas)
                .HasForeignKey("album_id");

            builder.HasOne(f => f.TipoMidia)
                .WithMany(tm => tm.Faixas)
                .HasForeignKey("tipo_midia_id");

            builder.HasOne(f => f.Genero)
                .WithMany(g => g.Faixas)
                .HasForeignKey("genero_id");

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
