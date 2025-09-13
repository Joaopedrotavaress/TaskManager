using System.ComponentModel.DataAnnotations;

namespace TaskManager.Dto
{
    public class TarefaCadastroDto
    {
        [Required]
        public string titulo { get; set; }

        [Required]
        public string descricao { get; set; }

        [Required]
        public int UsuarioId { get; set; }
    }
}