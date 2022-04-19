using Microsoft.EntityFrameworkCore;

namespace GameWebApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }
        public DbSet<Game> Games { get; set; }
    }
}
