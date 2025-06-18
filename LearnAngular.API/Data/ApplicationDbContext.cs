using LearnAngular.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(p => p.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Product>().Property(p => p.UpdatedDate).HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Product>().Property(p => p.IsActive).HasDefaultValue(true);
        }
    }
}
