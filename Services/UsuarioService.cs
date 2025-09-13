using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
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
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
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
            _appDbContext.Entry(usuario).CurrentValues.SetValues(usuarioAtualizado);
            await _appDbContext.SaveChangesAsync();
            return usuarioAtualizado;
        }
        public async Task<Usuario> deleteUsuarioAsync(int id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
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