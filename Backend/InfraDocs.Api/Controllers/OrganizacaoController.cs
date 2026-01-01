using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Organizacao;
using InfraDocs.Shared.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = PolicyNames.AdminOuUsuario)]
    public class OrganizacaoController : ControllerBase
    {
        private readonly IOrganizacaoService _service;

        public OrganizacaoController(IOrganizacaoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadOrganizacaoDto>>> GetAll()
        {
            var organizacoes = await _service.GetAllAsync();
            return Ok(organizacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> GetById(int id)
        {
            var organizacao = await _service.GetByIdAsync(id);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada.");

            return Ok(organizacao);
        }

        [HttpGet("documento/{documento}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> GetByDocumento(string documento)
        {
            var organizacao = await _service.GetByDocumentoAsync(documento);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada.");

            return Ok(organizacao);
        }
        

        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpPost]
        public async Task<ActionResult<ReadOrganizacaoDto>> Create(
            [FromBody] CreateOrganizacaoDto dto)
        {
            var organizacao = await _service.CreateAsync(dto);

            if (organizacao == null || organizacao.Id == 0)
                return BadRequest("Erro ao criar organização.");

            return Ok(organizacao);
        }

        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> Update(
            int id,
            [FromBody] UpdateOrganizacaoDto dto)
        {
            var organizacao = await _service.UpdateAsync(id, dto);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada para atualização.");

            return Ok(organizacao);
        }

        [Authorize(Policy = PolicyNames.Administrador)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
                return NotFound("Organização não encontrada para exclusão.");

            return NoContent();
        }
    }
}
