using InfraDocs.Domain.Currents.Interfaces;

namespace InfraDocs.Domain.Currents.Implementations
{
    public class CurrentUsuario : ICurrentUsuario
    {
        public int? UsuarioId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;

    }
}
