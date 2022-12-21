using AdoptMe1.Models;
using Microsoft.EntityFrameworkCore;

namespace AdpotMe1API.Data
{
    public class ApiAnimalContext : DbContext
    {
        public ApiAnimalContext(DbContextOptions<ApiAnimalContext> dbContext) : base(dbContext){ }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
