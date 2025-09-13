using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TarefaService
    {
        private readonly AppDbContext _appDbContext;

        public TarefaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Tarefas> addTarefaAsync(Tarefas tarefa)
        {
            _appDbContext.Tarefas.Add(tarefa);
            await _appDbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<List<Tarefas>> GetTarefasAsync()
        {
            List<Tarefas> tarefas = await _appDbContext.Tarefas.ToListAsync();
            return tarefas;
        }

        public async Task<List<Tarefas>> getTarefasIdAsync(int id)
        {
            var consulta = _appDbContext.Tarefas.Where(e => e.UsuarioId == id);
            return await consulta.ToListAsync();
        }

        public async Task<List<Tarefas>> getTarefasStatusAsync(String status)
        {
            var consulta = _appDbContext.Tarefas.Where(e => e.Status.Equals(status));
            return await consulta.ToListAsync();
        }
        public async Task<List<Tarefas>> getTarefasPeriodoAsync(DateTime inicio, DateTime final)
        {
            var consulta = _appDbContext.Tarefas.Where(e => e.DataCriacao >= inicio && e.DataCriacao <= final);
            return await consulta.ToListAsync();
        }

        public async Task<Tarefas> putTarefaAsync(int id, Tarefas tarefaAtualizado)
        {
            var tarefaExistente = await _appDbContext.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
            {
                return null;
            }
            tarefaExistente.Titulo = tarefaAtualizado.Titulo;
            tarefaExistente.Descricao = tarefaAtualizado.Descricao;
            tarefaExistente.UsuarioId = tarefaAtualizado.UsuarioId;

            await _appDbContext.SaveChangesAsync();
            return tarefaExistente;
        }

        public async Task<Tarefas> deleteTarefaAsync(int id)
        {
            var tarefaExistente = await _appDbContext.Tarefas.FindAsync(id);
            if (tarefaExistente == null)
            {
                return null;
            }
            _appDbContext.Remove(tarefaExistente);
            await _appDbContext.SaveChangesAsync();
            return tarefaExistente;
        }
    }
}