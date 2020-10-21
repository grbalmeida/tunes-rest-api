using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Tunes.Api.Extensions;
using Tunes.Business.Interfaces.Repository;
using Tunes.Business.Interfaces.Services;
using Tunes.Business.Interfaces;
using Tunes.Data.Context;
using Tunes.Data.Repository;
using Tunes.Business.Notifications;
using Tunes.Business.Services;

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

            services.AddScoped<IArtistaService, ArtistaService>();

            services.AddScoped<INotifier, Notifier>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
