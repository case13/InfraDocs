using InfraDocs.Shared.Authorizations;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InfraDocs.Shared.Dtos.Common;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = PolicyNames.AdminOuUsuario)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("paginado")]
        public async Task<ActionResult<PagedResultDto<ReadUsuarioDto>>> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? filterColumn = null,
            [FromQuery] string? filterText = null)
        {
            var result = await _service.GetPagedAsync(pageNumber, pageSize, filterColumn, filterText);
            return Ok(result);
        }

        // Leitura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUsuarioDto>>> GetAll()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadUsuarioDto>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);

            if (usuario == null || usuario.Id == 0)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        // Escrita
        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpPost]
        public async Task<ActionResult<ReadUsuarioDto>> Create([FromBody] CreateUsuarioDto dto)
        {
            var usuario = await _service.CreateAsync(dto);

            if (usuario == null || usuario.Id == 0)
                return BadRequest("Erro ao criar usuário.");

            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadUsuarioDto>> Update(
            int id,
            [FromBody] UpdateUsuarioDto dto)
        {
            var usuario = await _service.UpdateAsync(id, dto);

            if (usuario == null || usuario.Id == 0)
                return NotFound("Usuário não encontrado para atualização.");

            return Ok(usuario);
        }

        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Usuário não encontrado para exclusão.");

            return NoContent();
        }
    }
}
