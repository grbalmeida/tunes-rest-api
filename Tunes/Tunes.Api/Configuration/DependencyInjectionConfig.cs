using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Tunes.Api.Extensions;
using Tunes.Business.Interfaces;
using Tunes.Data.Context;
using Tunes.Data.Repository;

namespace Tunes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<TunesContext>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFaixaRepository, FaixaRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IItemNotaFiscalRepository, ItemNotaFiscalRepository>();
            services.AddScoped<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddScoped<IPlaylistFaixaRepository, PlaylistFaixaRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<ITipoMidiaRepository, TipoMidiaRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
