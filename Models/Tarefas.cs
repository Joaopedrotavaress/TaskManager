using System;

namespace TaskManager.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } = "Pendente";
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Descrição: {Descricao}, Status: {Status}, Data de Criação: {DataCriacao}, Usuário ID: {UsuarioId}";
        }
    }
}
