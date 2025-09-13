using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto
{
    public class UsuarioCadastroDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
    }
}