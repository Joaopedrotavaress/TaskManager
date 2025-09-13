using Microsoft.EntityFrameworkCore;
using TaskManager.Codigo.Models;

namespace TaskManager.Codigo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
