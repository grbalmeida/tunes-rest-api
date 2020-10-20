using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tunes.Business.Models;

namespace Tunes.Data.Context
{
    public class TunesContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<TipoMidia> TiposDeMidia { get; set; }
        public DbSet<Faixa> Faixas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<ItemNotaFiscal> ItensNotaFiscal { get; set; }

        public TunesContext(DbContextOptions<TunesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TunesContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
