using AutoMapper;
using PruebaTecnica.Models.Dtos.Usuarios;
using PruebaTecnica.Models.Entities;

namespace PruebaTecnica.Helpers.AutoMapping
{
    public class AutoMappingHelper : Profile
    {
        public AutoMappingHelper()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
