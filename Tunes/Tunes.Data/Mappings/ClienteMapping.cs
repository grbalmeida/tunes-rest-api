using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.Property(c => c.ClienteId)
                .HasColumnName("cliente_id");

            builder.Property(c => c.PrimeiroNome)
                .HasColumnName("primeiro_nome")
                .HasColumnType("varchar(40)")
                .IsRequired();

            builder.Property(c => c.Sobrenome)
                .HasColumnName("sobrenome")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(c => c.Empresa)
                .HasColumnName("empresa")
                .HasColumnType("varchar(80)");

            builder.Property(c => c.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(70)");

            builder.Property(c => c.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(40)");

            builder.Property(c => c.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(40)");

            builder.Property(c => c.Pais)
                .HasColumnName("pais")
                .HasColumnType("varchar(40)");

            builder.Property(c => c.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.Fone)
                .HasColumnName("fone")
                .HasColumnType("varchar(24)");

            builder.Property(c => c.Fax)
                .HasColumnName("fax")
                .HasColumnType("varchar(24)");

            builder.Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(60)")
                .IsRequired();

            builder.Property<int?>("suporte_id");

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasOne(c => c.Suporte)
                .WithMany(f => f.ClientesAtendidos)
                .HasForeignKey("suporte_id");
        }
    }
}
