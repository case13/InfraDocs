using InfraDocs.Application.Services.Interfaces;
using InfraDocs.Domain.Repositories.Interfaces;
using InfraDocs.Shared.Dtos.Auth;
using InfraDocs.Shared.Dtos.Usuario;
using AutoMapper;

namespace InfraDocs.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(
            IUsuarioRepository usuarioRepository,
            IRefreshTokenRepository refreshTokenRepository,
            ITokenService tokenService,
            IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<LoginResultDto> LoginAsync(string email)
        {
            var usuario = await _usuarioRepository.GetByEmailForLoginAsync(email);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            var accessToken = _tokenService.GenerateAccessToken(usuario);
            var refreshToken = _tokenService.GenerateRefreshToken();

            refreshToken.UsuarioId = usuario.Id;

            await _refreshTokenRepository.AddAsync(refreshToken);
            await _refreshTokenRepository.SaveChangesAsync();

            return new LoginResultDto
            {
                Usuario = _mapper.Map<ReadUsuarioDto>(usuario),
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }

        public async Task<LoginResultDto> RefreshAsync(string token)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(token);

            if (refreshToken == null || !refreshToken.IsValid)
                throw new UnauthorizedAccessException("Refresh token inválido.");

            refreshToken.RevokedAt = DateTime.UtcNow;

            var newAccessToken =
                _tokenService.GenerateAccessToken(refreshToken.Usuario);

            var newRefreshToken =
                _tokenService.GenerateRefreshToken();

            newRefreshToken.UsuarioId = refreshToken.UsuarioId;

            await _refreshTokenRepository.AddAsync(newRefreshToken);
            await _refreshTokenRepository.SaveChangesAsync();

            return new LoginResultDto
            {
                Usuario = _mapper.Map<ReadUsuarioDto>(refreshToken.Usuario),
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }
    }
}
