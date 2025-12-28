using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.RequerimentoSuspensaoRestricao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RequerimentoSuspensaoRestricaoController : ControllerBase
    {
        private readonly IRequerimentoSuspensaoRestricaoService _service;

        public RequerimentoSuspensaoRestricaoController(
            IRequerimentoSuspensaoRestricaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os requerimentos da organização logada
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadRequerimentoSuspensaoRestricaoDto>>> GetAll()
        {
            var itens = await _service.GetAllAsync();
            return Ok(itens);
        }

        /// <summary>
        /// Obtém um requerimento por ID
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadRequerimentoSuspensaoRestricaoDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);

            if (item == null || item.Id == 0)
                return NotFound("Requerimento não encontrado.");

            return Ok(item);
        }

        /// <summary>
        /// Cria um novo requerimento
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ReadRequerimentoSuspensaoRestricaoDto>> Create(
            [FromBody] CreateRequerimentoSuspensaoRestricaoDto dto)
        {
            var item = await _service.CreateAsync(dto);

            if (item == null || item.Id == 0)
                return BadRequest("Erro ao criar requerimento.");

            return Ok(item);
        }

        /// <summary>
        /// Atualiza um requerimento existente
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadRequerimentoSuspensaoRestricaoDto>> Update(
            int id,
            [FromBody] UpdateRequerimentoSuspensaoRestricaoDto dto)
        {
            var item = await _service.UpdateAsync(id, dto);

            if (item == null || item.Id == 0)
                return NotFound("Requerimento não encontrado para atualização.");

            return Ok(item);
        }

        /// <summary>
        /// Remove um requerimento
        /// </summary>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Requerimento não encontrado para exclusão.");

            return NoContent();
        }
    }
}
