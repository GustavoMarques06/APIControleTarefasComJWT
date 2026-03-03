namespace APIControleTarefasComAutenticação.Domain.Entities
{
    public class ToDo
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
