using LearnAngular.API.Data;
using LearnAngular.API.Models.Domain;
using LearnAngular.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnAngular.API.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Product> CreateAsync([FromBody] Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> UpdateAsync([FromBody] Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct is not null)
            {
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
                await _dbContext.SaveChangesAsync();
                return  product;
            }
            
            return null;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // return Task.FromResult<IEnumerable<Product>>(dbContext.Products.ToList());
            return await _dbContext.Products.ToListAsync();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            return _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
