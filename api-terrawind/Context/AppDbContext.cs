using api_terrawind.Models;
using Microsoft.EntityFrameworkCore;

namespace api_terrawind.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Gestores>  Gestores { get; set; }
    }
}
