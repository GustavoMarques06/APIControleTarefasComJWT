using APIControleTarefasComAutenticação.Application.DTO_s.Request;

namespace APIControleTarefasComAutenticação.Application.DTO_s.Response
{
    public class ToDoResponseDto: CreateToDoDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
