using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class NotaFiscalMapping : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.ToTable("nota_fiscal");

            builder.Property(nf => nf.NotaFiscalId)
                .HasColumnName("nota_fiscal_id");

            builder.Property<int>("cliente_id");

            builder.Property(nf => nf.DataNotaFiscal)
                .HasColumnName("data_nota_fiscal")
                .HasColumnType("datetime");

            builder.Property(nf => nf.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(70)");

            builder.Property(nf => nf.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(40)");

            builder.Property(nf => nf.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(40)");

            builder.Property(nf => nf.Pais)
                .HasColumnName("pais")
                .HasColumnType("varchar(40)");

            builder.Property(nf => nf.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(10)");

            builder.Property(nf => nf.Total)
                .HasColumnName("total")
                .HasColumnType("numeric(10, 2)");

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasOne(nf => nf.Cliente)
                .WithMany(c => c.NotasFiscais)
                .HasForeignKey("cliente_id");
        }
    }
}
