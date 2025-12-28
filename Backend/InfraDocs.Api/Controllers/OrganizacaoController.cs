using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Shared.Dtos.Organizacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizacaoController : ControllerBase
    {
        private readonly IOrganizacaoService _service;

        public OrganizacaoController(IOrganizacaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as organizações
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadOrganizacaoDto>>> GetAll()
        {
            var organizacoes = await _service.GetAllAsync();
            return Ok(organizacoes);
        }

        /// <summary>
        /// Obtém uma organização por ID
        /// </summary>
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> GetById(int id)
        {
            var organizacao = await _service.GetByIdAsync(id);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada.");

            return Ok(organizacao);
        }

        /// <summary>
        /// Cria uma nova organização
        /// (permitido sem autenticação para onboarding)
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ReadOrganizacaoDto>> Create(
            [FromBody] CreateOrganizacaoDto dto)
        {
            var organizacao = await _service.CreateAsync(dto);

            if (organizacao == null || organizacao.Id == 0)
                return BadRequest("Erro ao criar organização.");

            return Ok(organizacao);
        }

        /// <summary>
        /// Atualiza uma organização existente
        /// </summary>
        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> Update(
            int id,
            [FromBody] UpdateOrganizacaoDto dto)
        {
            var organizacao = await _service.UpdateAsync(id, dto);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada para atualização.");

            return Ok(organizacao);
        }

        /// <summary>
        /// Busca organização pelo documento (CPF/CNPJ)
        /// </summary>
        [Authorize]
        [HttpGet("documento/{documento}")]
        public async Task<ActionResult<ReadOrganizacaoDto>> GetByDocumento(string documento)
        {
            var organizacao = await _service.GetByDocumentoAsync(documento);

            if (organizacao == null || organizacao.Id == 0)
                return NotFound("Organização não encontrada com esse documento.");

            return Ok(organizacao);
        }
    }
}
