using AutoMapper;
using Tunes.Api.ViewModels;
using Tunes.Business.Models;

namespace Tunes.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Album, AlbumViewModel>().ReverseMap();
            CreateMap<Artista, ArtistaViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Faixa, FaixaViewModel>().ReverseMap();
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
            CreateMap<Genero, GeneroViewModel>().ReverseMap();
            CreateMap<ItemNotaFiscal, ItemNotaFiscalViewModel>().ReverseMap();
            CreateMap<NotaFiscal, NotaFiscalViewModel>().ReverseMap();
            CreateMap<Playlist, PlaylistViewModel>().ReverseMap();
            CreateMap<PlaylistFaixa, PlaylistFaixaViewModel>().ReverseMap();
            CreateMap<TipoMidia, TipoMidiaViewModel>().ReverseMap();
        }
    }
}
