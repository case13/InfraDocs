namespace InfraDocs.Domain.Currents.Interfaces
{
    public interface ICurrentUser
    {
        int? UsuarioId { get; }
        string? Email { get; }
        string? Nome { get; }
        string? TipoUsuario { get; }
    }
}
