namespace APIControleTarefasComAutenticação.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
