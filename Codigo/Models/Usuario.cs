
namespace TaskManager.Codigo.Models
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public List<Tarefas> Tarefas { get; set; } = new List<Tarefas>();
        public Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Email: {Email}, Tarefas: [{string.Join(", ", Tarefas)}]";
        }
    }
}
