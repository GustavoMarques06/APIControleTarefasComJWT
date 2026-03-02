using APIControleTarefasComAutenticação.Domain.Entities;

namespace APIControleTarefasComAutenticação.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);

        Task AddAsync(User user);

        Task UpdateAsync(User user);
    }
}
