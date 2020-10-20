using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class ItemNotaFiscalMapping : IEntityTypeConfiguration<ItemNotaFiscal>
    {
        public void Configure(EntityTypeBuilder<ItemNotaFiscal> builder)
        {
            builder.ToTable("item_nota_fiscal");

            builder.Property(inf => inf.ItemNotaFiscalId)
                .HasColumnName("item_nota_fiscal_id");

            builder.Property<int>("nota_fiscal_id");

            builder.Property<int>("faixa_id");

            builder.Property(inf => inf.PrecoUnitario)
                .HasColumnName("preco_unitario")
                .HasColumnType("numeric(10, 2)");

            builder.Property(inf => inf.Quantidade)
                .HasColumnName("quantidade");

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasOne(inf => inf.NotaFiscal)
                .WithMany(nf => nf.ItensNotaFiscal)
                .HasForeignKey("nota_fiscal_id");

            builder.HasOne(inf => inf.Faixa)
                .WithMany(nf => nf.ItensNotaFiscal)
                .HasForeignKey("faixa_id");
        }
    }
}
