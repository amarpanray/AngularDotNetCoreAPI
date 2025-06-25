using LearnAngular.API.Models.Domain;
using LearnAngular.API.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace LearnAngular.API.Data
{
    public class MongoDbContext: DbContext
    {
       // private readonly IConfiguration _configuration;

        public DbSet<Customer> Customers { get; set; } = null!;
        public MongoDbContext(DbContextOptions<MongoDbContext> options/*, IConfiguration configuration*/) : base(options)
        {
           // _configuration = configuration;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Customer>();
            //modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            //modelBuilder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(50);
            //modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(100);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        var mongoDBSettings = _configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
        //        optionsBuilder.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? "");
        //    }
        //}

    }
}
