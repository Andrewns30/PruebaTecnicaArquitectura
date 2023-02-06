using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Usuarios;

namespace PruebaTecnica.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<ResponseServiceDto<List<UsuarioDto>>> GetUsers();
    }
}