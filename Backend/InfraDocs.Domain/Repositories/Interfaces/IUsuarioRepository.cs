using InfraDocs.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfraDocs.Domain.Repositories.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
