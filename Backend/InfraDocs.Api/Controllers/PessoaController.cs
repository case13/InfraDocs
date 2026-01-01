using InfraDocs.Shared.Authorizations;
using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Pessoa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = PolicyNames.SomenteLeitura)]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        // Leitura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPessoaDto>>> GetAll()
        {
            var pessoas = await _service.GetAllAsync();
            return Ok(pessoas);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadPessoaDto>> GetById(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);

            if (pessoa == null || pessoa.Id == 0)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        // Escrita
        [Authorize(Policy = PolicyNames.AdminOuUsuario)]
        [HttpPost]
        public async Task<ActionResult<ReadPessoaDto>> Create(
            [FromBody] CreatePessoaDto dto)
        {
            var pessoa = await _service.CreateAsync(dto);

            if (pessoa == null || pessoa.Id == 0)
                return BadRequest("Erro ao criar pessoa.");

            return Ok(pessoa);
        }

        [Authorize(Policy = PolicyNames.AdminOuUsuario)]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadPessoaDto>> Update(
            int id,
            [FromBody] UpdatePessoaDto dto)
        {
            var pessoa = await _service.UpdateAsync(id, dto);

            if (pessoa == null || pessoa.Id == 0)
                return NotFound("Pessoa não encontrada para atualização.");

            return Ok(pessoa);
        }

        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Pessoa não encontrada para exclusão.");

            return NoContent();
        }
    }
}
