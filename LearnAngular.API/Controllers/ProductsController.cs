using LearnAngular.API.Data;
using LearnAngular.API.Models.Domain;
using LearnAngular.API.Models.DTO;
using LearnAngular.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LearnAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductRepository ProductRepository { get; }


        // This is a placeholder for the ProductsController.
        // You can implement methods to handle HTTP requests related to products here.
        // For example, you might have methods for getting, creating, updating, and deleting products.

        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok("This will return a list of products.");
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO request)
        {
            //Map Domain Object to Data Transfer Object (DTO)
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate,
                IsActive = request.IsActive,
                CreatedBy = request.CreatedBy
            };

            //Abstracting this task to the repository layer
            //by taking advantage of the Unit of Work pattern
            await ProductRepository.CreateAsync(product);

            //Map DTO back to Domain Object
            var response = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                CreatedDate = product.CreatedDate,
                UpdatedDate = product.UpdatedDate,
                IsActive = product.IsActive,
                CreatedBy = product.CreatedBy
            };

            return Ok(response);
        }
    }
}
