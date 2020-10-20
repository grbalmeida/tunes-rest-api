using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Tunes.Business.Models;

namespace Tunes.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("funcionario");

            builder.Property(f => f.FuncionarioId)
                .HasColumnName("funcionario_id");

            builder.Property(f => f.PrimeiroNome)
                .HasColumnName("primeiro_nome")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(f => f.Sobrenome)
                .HasColumnName("sobrenome")
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(f => f.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(30)");

            builder.Property<int?>("se_reporta_a");

            builder.Property(f => f.DataNascimento)
                .HasColumnName("data_nascimento")
                .HasColumnType("datetime");

            builder.Property(f => f.DataAdmissao)
                .HasColumnName("data_admissao")
                .HasColumnType("datetime");

            builder.Property(f => f.Endereco)
                .HasColumnName("endereco")
                .HasColumnType("varchar(70)");

            builder.Property(f => f.Cidade)
                .HasColumnName("cidade")
                .HasColumnType("varchar(40)");

            builder.Property(f => f.Estado)
                .HasColumnName("estado")
                .HasColumnType("varchar(40)");

            builder.Property(f => f.Pais)
                .HasColumnName("pais")
                .HasColumnType("varchar(40)");

            builder.Property(f => f.CEP)
                .HasColumnName("cep")
                .HasColumnType("varchar(10)");

            builder.Property(f => f.Fone)
                .HasColumnName("fone")
                .HasColumnType("varchar(24)");

            builder.Property(f => f.Fax)
                .HasColumnName("fax")
                .HasColumnType("varchar(24)");

            builder.Property(f => f.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(60)");

            builder.HasOne(f => f.Gerente)
                .WithMany(g => g.Equipe)
                .HasForeignKey("se_reporta_a");

            builder.Property<DateTime>("data_criacao")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}
