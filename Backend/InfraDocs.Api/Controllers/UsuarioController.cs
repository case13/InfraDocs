using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os usuários da organização logada
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadUsuarioDto>>> GetAll()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Busca usuário por ID (respeitando organização)
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadUsuarioDto>> GetById(int id)
        {
            var usuario = await _service.GetByIdAsync(id);

            if (usuario == null || usuario.Id == 0)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ReadUsuarioDto>> Create(
            [FromBody] CreateUsuarioDto dto)
        {
            var usuario = await _service.CreateAsync(dto);

            if (usuario == null || usuario.Id == 0)
                return BadRequest("Erro ao criar usuário.");

            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
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

        /// <summary>
        /// Remove (inativa) um usuário
        /// </summary>
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
