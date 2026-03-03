using APIControleTarefasComAutenticação.Application.DTO_s.Request;
using APIControleTarefasComAutenticação.Application.DTO_s.Response;
using APIControleTarefasComAutenticação.Application.Interfaces;
using APIControleTarefasComAutenticação.Domain.Entities;
using APIControleTarefasComAutenticação.Domain.Interfaces;
using Humanizer;

namespace APIControleTarefasComAutenticação.Application.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }
        public async Task<List<ToDoResponseDto>> GetUserTodos(Guid userId)
        {
            var todos = await _toDoRepository.GetByUserId(userId);

            return todos.Select(todo => new ToDoResponseDto
            {
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt
            }).ToList();
        }

        public async Task<ToDo> Create(Guid userId, CreateToDoDto dto)
        {
            var toDo = new ToDo
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = dto.IsCompleted,
            };

            await _toDoRepository.Create(toDo);

            return toDo;
        }

    }
}
