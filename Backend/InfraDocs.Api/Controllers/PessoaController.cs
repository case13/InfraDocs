using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Pessoa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as pessoas da organização logada
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadPessoaDto>>> GetAll()
        {
            var pessoas = await _service.GetAllAsync();
            return Ok(pessoas);
        }

        /// <summary>
        /// Obtém uma pessoa por ID
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadPessoaDto>> GetById(int id)
        {
            var pessoa = await _service.GetByIdAsync(id);

            if (pessoa == null || pessoa.Id == 0)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        /// <summary>
        /// Cria uma nova pessoa
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ReadPessoaDto>> Create(
            [FromBody] CreatePessoaDto dto)
        {
            var pessoa = await _service.CreateAsync(dto);

            if (pessoa == null || pessoa.Id == 0)
                return BadRequest("Erro ao criar pessoa.");

            return Ok(pessoa);
        }

        /// <summary>
        /// Atualiza uma pessoa existente
        /// </summary>
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

        /// <summary>
        /// Remove uma pessoa
        /// </summary>
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
