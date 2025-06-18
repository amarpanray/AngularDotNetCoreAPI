using LearnAngular.API.Models.Domain;

namespace LearnAngular.API.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
    }
}
