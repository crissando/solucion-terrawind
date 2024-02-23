using api_terrawind.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_terrawind.Infraestructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Gestores> Gestores { get; set; }
    }
}
