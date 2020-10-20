﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tunes.Data.Context;

namespace Tunes.Data.Migrations
{
    [DbContext(typeof(TunesContext))]
    partial class TunesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tunes.Business.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("album_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("titulo")
                        .HasColumnType("varchar(160)");

                    b.Property<int>("artista_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("AlbumId");

                    b.HasIndex("artista_id");

                    b.ToTable("album");
                });

            modelBuilder.Entity("Tunes.Business.Models.Artista", b =>
                {
                    b.Property<int>("ArtistaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("artista_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("ArtistaId");

                    b.ToTable("artista");
                });

            modelBuilder.Entity("Tunes.Business.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("cliente_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnName("cep")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnName("cidade")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Empresa")
                        .HasColumnName("empresa")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Endereco")
                        .HasColumnName("endereco")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Fax")
                        .HasColumnName("fax")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Fone")
                        .HasColumnName("fone")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Pais")
                        .HasColumnName("pais")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnName("primeiro_nome")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("sobrenome")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("suporte_id")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.HasIndex("suporte_id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Tunes.Business.Models.Faixa", b =>
                {
                    b.Property<int>("FaixaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("faixa_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bytes")
                        .HasColumnName("bytes")
                        .HasColumnType("int");

                    b.Property<string>("Compositor")
                        .HasColumnName("compositor")
                        .HasColumnType("varchar(220)");

                    b.Property<int>("Milissegundos")
                        .HasColumnName("milissegundos")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnName("preco_unitario")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<int?>("album_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("genero_id")
                        .HasColumnType("int");

                    b.Property<int>("tipo_midia_id")
                        .HasColumnType("int");

                    b.HasKey("FaixaId");

                    b.HasIndex("album_id");

                    b.HasIndex("genero_id");

                    b.HasIndex("tipo_midia_id");

                    b.ToTable("faixa");
                });

            modelBuilder.Entity("Tunes.Business.Models.Funcionario", b =>
                {
                    b.Property<int>("FuncionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("funcionario_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnName("cep")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnName("cidade")
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnName("data_admissao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("data_nascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Endereco")
                        .HasColumnName("endereco")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Fax")
                        .HasColumnName("fax")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Fone")
                        .HasColumnName("fone")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Pais")
                        .HasColumnName("pais")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnName("primeiro_nome")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("sobrenome")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Titulo")
                        .HasColumnName("titulo")
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int?>("se_reporta_a")
                        .HasColumnType("int");

                    b.HasKey("FuncionarioId");

                    b.HasIndex("se_reporta_a");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("Tunes.Business.Models.Genero", b =>
                {
                    b.Property<int>("GeneroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("genero_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("GeneroId");

                    b.ToTable("genero");
                });

            modelBuilder.Entity("Tunes.Business.Models.ItemNotaFiscal", b =>
                {
                    b.Property<int>("ItemNotaFiscalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("item_nota_fiscal_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnName("preco_unitario")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<int>("Quantidade")
                        .HasColumnName("quantidade")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("faixa_id")
                        .HasColumnType("int");

                    b.Property<int>("nota_fiscal_id")
                        .HasColumnType("int");

                    b.HasKey("ItemNotaFiscalId");

                    b.HasIndex("faixa_id");

                    b.HasIndex("nota_fiscal_id");

                    b.ToTable("item_nota_fiscal");
                });

            modelBuilder.Entity("Tunes.Business.Models.NotaFiscal", b =>
                {
                    b.Property<int>("NotaFiscalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("nota_fiscal_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnName("cep")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Cidade")
                        .HasColumnName("cidade")
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("DataNotaFiscal")
                        .HasColumnName("data_nota_fiscal")
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .HasColumnName("endereco")
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Estado")
                        .HasColumnName("estado")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Pais")
                        .HasColumnName("pais")
                        .HasColumnType("varchar(40)");

                    b.Property<decimal>("Total")
                        .HasColumnName("total")
                        .HasColumnType("numeric(10, 2)");

                    b.Property<int>("cliente_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("NotaFiscalId");

                    b.HasIndex("cliente_id");

                    b.ToTable("nota_fiscal");
                });

            modelBuilder.Entity("Tunes.Business.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("playlist_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("PlaylistId");

                    b.ToTable("playlist");
                });

            modelBuilder.Entity("Tunes.Business.Models.PlaylistFaixa", b =>
                {
                    b.Property<int>("playlist_id")
                        .HasColumnType("int");

                    b.Property<int>("faixa_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("playlist_id", "faixa_id");

                    b.HasIndex("faixa_id");

                    b.ToTable("playlist_faixa");
                });

            modelBuilder.Entity("Tunes.Business.Models.TipoMidia", b =>
                {
                    b.Property<int>("TipoMidiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tipo_midia_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime>("data_criacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("TipoMidiaId");

                    b.ToTable("tipo_midia");
                });

            modelBuilder.Entity("Tunes.Business.Models.Album", b =>
                {
                    b.HasOne("Tunes.Business.Models.Artista", "Artista")
                        .WithMany("Albuns")
                        .HasForeignKey("artista_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tunes.Business.Models.Cliente", b =>
                {
                    b.HasOne("Tunes.Business.Models.Funcionario", "Suporte")
                        .WithMany("ClientesAtendidos")
                        .HasForeignKey("suporte_id");
                });

            modelBuilder.Entity("Tunes.Business.Models.Faixa", b =>
                {
                    b.HasOne("Tunes.Business.Models.Album", "Album")
                        .WithMany("Faixas")
                        .HasForeignKey("album_id");

                    b.HasOne("Tunes.Business.Models.Genero", "Genero")
                        .WithMany("Faixas")
                        .HasForeignKey("genero_id");

                    b.HasOne("Tunes.Business.Models.TipoMidia", "TipoMidia")
                        .WithMany("Faixas")
                        .HasForeignKey("tipo_midia_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tunes.Business.Models.Funcionario", b =>
                {
                    b.HasOne("Tunes.Business.Models.Funcionario", "Gerente")
                        .WithMany("Equipe")
                        .HasForeignKey("se_reporta_a");
                });

            modelBuilder.Entity("Tunes.Business.Models.ItemNotaFiscal", b =>
                {
                    b.HasOne("Tunes.Business.Models.Faixa", "Faixa")
                        .WithMany("ItensNotaFiscal")
                        .HasForeignKey("faixa_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunes.Business.Models.NotaFiscal", "NotaFiscal")
                        .WithMany("ItensNotaFiscal")
                        .HasForeignKey("nota_fiscal_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tunes.Business.Models.NotaFiscal", b =>
                {
                    b.HasOne("Tunes.Business.Models.Cliente", "Cliente")
                        .WithMany("NotasFiscais")
                        .HasForeignKey("cliente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tunes.Business.Models.PlaylistFaixa", b =>
                {
                    b.HasOne("Tunes.Business.Models.Faixa", "Faixa")
                        .WithMany("Playlists")
                        .HasForeignKey("faixa_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tunes.Business.Models.Playlist", "Playlist")
                        .WithMany("Faixas")
                        .HasForeignKey("playlist_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
