using APIControleTarefasComAutenticação.Domain.Entities;

namespace APIControleTarefasComAutenticação.Domain.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetByUserId(Guid userId);
        Task Create(ToDo toDo);
    }
}
