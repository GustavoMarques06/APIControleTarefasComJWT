using APIControleTarefasComAutenticação.Application.DTO_s.Request;
using APIControleTarefasComAutenticação.Application.DTO_s.Response;
using APIControleTarefasComAutenticação.Domain.Entities;

namespace APIControleTarefasComAutenticação.Application.Interfaces
{
    public interface IToDoService
    {
        Task<List<ToDoResponseDto>> GetUserTodos(Guid userId);
        Task<ToDo> Create(Guid userId, CreateToDoDto dto);

    }
}
