using PruebaTecnica.Models.Dtos;
using PruebaTecnica.Models.Entities;
using AutoMapper;
using PruebaTecnica.DataAccess.Repository;
using PruebaTecnica.Helpers.LoggerManager;
using PruebaTecnica.Helpers.Extensions;
using PruebaTecnica.Models.Dtos.Usuarios;
using PruebaTecnica.Services.Interfaces;

namespace PruebaTecnica.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Fields
        private readonly IDataRepository<Usuario> _usuarioRepo;
        private readonly IMapper _mapper;
        private readonly ILog _log;
        #endregion

        #region Builder
        public UsuarioService(IDataRepository<Usuario> usuarioRepo, IMapper mapper, ILog log)
        {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
            _log = log;
        }
        #endregion

        public async Task<ResponseServiceDto<List<UsuarioDto>>> GetUsers()
        {
            ResponseServiceDto<List<UsuarioDto>> responseGenericDto = new();
            try
            {
                List<Usuario> usuarios = await _usuarioRepo.List();

                return await responseGenericDto.GetResultSucces(_mapper.Map<List<UsuarioDto>>(usuarios));
            }
            catch (Exception e)
            {
                _log.LogError(e);
                return await responseGenericDto.GetResultError();
            }
        }
    }
}
