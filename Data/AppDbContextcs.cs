using Microsoft.EntityFrameworkCore;
using GraphApi.Models;

namespace GraphApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}