using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Dtos.Usuarios;
using PruebaTecnica.Services.Interfaces;

namespace PruebaTecnica.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Metodo que retorna una lista usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<ResponseServiceDto<List<UsuarioDto>>>> GetUsers()
        {
            ResponseServiceDto<List<UsuarioDto>> response = await _usuarioService.GetUsers();
            return Ok(response);
        }
    }
}
