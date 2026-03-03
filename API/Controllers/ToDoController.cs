using APIControleTarefasComAutenticação.Application.DTO_s.Request;
using APIControleTarefasComAutenticação.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIControleTarefasComAutenticação.API.Controllers
{
    [ApiController]
    [Route("ToDos")]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService toDoService)
        {
            _service = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = Guid.Parse(
                User.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );
            var todos = await _service.GetUserTodos(userId);

            return Ok(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoDto dto)
        {
            var userId = Guid.Parse(
                User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value
            );

            var todo = await _service.Create(userId, dto);

            return Ok(todo);
        }
    }
}
