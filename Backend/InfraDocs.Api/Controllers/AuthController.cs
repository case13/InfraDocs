using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfraDocs.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public AuthController(
            IUsuarioRepository usuarioRepository,
            ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Login inicial (sem senha por enquanto) – gera JWT
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest("E-mail é obrigatório.");
            
            var usuario = await _usuarioRepository.GetByEmailForLoginAsync(email);

            if (usuario == null)
                return Unauthorized("Usuário não encontrado.");
            
            var token = _tokenService.GenerateToken(usuario);

            return Ok(new
            {
                accessToken = token
            });
        }
    }
}
