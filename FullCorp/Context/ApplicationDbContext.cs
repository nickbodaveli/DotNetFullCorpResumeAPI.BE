using FullCorp.Models.Entity;
using FullCorp.Models.Entity.Auth;
using Microsoft.EntityFrameworkCore;

namespace FullCorp.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<WorkingExperience> WorkingExperience => Set<WorkingExperience>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Skill> Skills => Set<Skill>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedAt = DateTime.Now
                },
                new Role()
                {
                    Id = 2,
                    Name = "User",
                    CreatedAt = DateTime.Now
                }
            );
        }
    }
}
