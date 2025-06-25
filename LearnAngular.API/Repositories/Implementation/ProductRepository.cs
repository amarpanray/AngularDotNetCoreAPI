using LearnAngular.API.Data;
using LearnAngular.API.Models.Domain;
using LearnAngular.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> CreateAsync([FromBody] Product product)
        {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // return Task.FromResult<IEnumerable<Product>>(dbContext.Products.ToList());
            return await dbContext.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            return dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
