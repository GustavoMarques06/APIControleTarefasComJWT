using APIControleTarefasComAutenticação.Domain.Entities;

namespace APIControleTarefasComAutenticação.Application.DTO_s.Request
{
    public class CreateToDoDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
