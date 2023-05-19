using Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Staff> Staff { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
