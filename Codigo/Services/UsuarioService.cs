using Microsoft.EntityFrameworkCore;
using TaskManager.Codigo.Data;
using TaskManager.Codigo.Models;

namespace TaskManager.Codigo.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _appDbContext;
        private readonly TarefaService _tarefasService;

        public UsuarioService(AppDbContext appDbContext, TarefaService tarefaService)
        {
            _appDbContext = appDbContext;
            _tarefasService = tarefaService;
        }
        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            var usuarioExistente = await _appDbContext.Usuarios
                                                            .FirstOrDefaultAsync(u => u.Email.Equals(usuario.Email));
            if (usuarioExistente != null)
                return null;                                                
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;

        }
        public async Task<List<Usuario>> getUsuariosAsync()
        {
            var usuarios = await _appDbContext.Usuarios.ToListAsync();

            return usuarios;

        }
        public async Task<Usuario> getUsuarioIdAsync(int id)
        {
            var usuario = await _appDbContext.Usuarios
                                    .Include(u => u.Tarefas) 
                                    .FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
                return null;
            return usuario;
        }
        public async Task<Usuario> updateUsuarioAsync(int id, Usuario usuarioAtualizado)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return null;
            }

            usuario.Email = usuarioAtualizado.Email;
            usuario.Nome = usuarioAtualizado.Nome;

            await _appDbContext.SaveChangesAsync();
            return usuarioAtualizado;
        }
        public async Task<Usuario> deleteUsuarioAsync(int id)
        {
            var usuario = await _appDbContext.Usuarios
                                    .Include(u => u.Tarefas) 
                                    .FirstOrDefaultAsync(u => u.Id == id);
            if (usuario == null)
            {
                return null;
            }
            _appDbContext.Usuarios.Remove(usuario);
            await _appDbContext.SaveChangesAsync();
            return usuario;
        }


    }
}