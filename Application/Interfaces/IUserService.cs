using APIControleTarefasComAutenticação.Application.DTO_s;
using APIControleTarefasComAutenticação.Application.DTO_s.Response;

namespace APIControleTarefasComAutenticação.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<LoginResponseDto> LoginAsync(LoginUserDto dto);
    }
}
