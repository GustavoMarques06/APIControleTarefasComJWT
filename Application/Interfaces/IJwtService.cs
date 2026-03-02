using APIControleTarefasComAutenticação.Domain.Entities;

namespace APIControleTarefasComAutenticação.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
