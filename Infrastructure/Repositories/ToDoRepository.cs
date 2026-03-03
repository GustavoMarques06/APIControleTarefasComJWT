using APIControleTarefasComAutenticação.Domain.Entities;
using APIControleTarefasComAutenticação.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIControleTarefasComAutenticação.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _context;
        public ToDoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ToDo toDo)
        {
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDo>> GetByUserId(Guid userId)
        {
            return await _context.ToDos
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
    }
}
