using LearnAngular.API.Models.Domain;
using LearnAngular.API.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using MongoDB.EntityFrameworkCore.Extensions;

namespace LearnAngular.API.Data
{
    public class MongoDbContext: DbContext
    {
       // private readonly IConfiguration _configuration;

      
        public DbSet<User> Users { get; init; }
        public MongoDbContext(DbContextOptions<MongoDbContext> options/*, IConfiguration configuration*/) : base(options)
        {
            // _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<User>().ToCollection("users");
            //Add other MongoDB Collections here as needed
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
