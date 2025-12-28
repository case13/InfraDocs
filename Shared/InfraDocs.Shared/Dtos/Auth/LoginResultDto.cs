using InfraDocs.Shared.Dtos.Usuario;

namespace InfraDocs.Shared.Dtos.Auth
{
    public class LoginResultDto
    {
        public ReadUsuarioDto Usuario { get; set; } = null!;
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
