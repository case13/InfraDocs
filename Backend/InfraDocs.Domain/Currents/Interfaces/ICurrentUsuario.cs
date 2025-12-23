namespace InfraDocs.Domain.Currents.Interfaces
{
    public interface ICurrentUsuario
    {
        int? UsuarioId { get; }
        string Email { get; }
        string Nome { get; }
    }
}
