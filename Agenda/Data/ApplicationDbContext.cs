using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class ApplicationDbContext : DbContext // Certifique-se de herdar de DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Adicione aqui DbSet para suas entidades

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
