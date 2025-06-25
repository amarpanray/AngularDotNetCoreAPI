using LearnAngular.API.Data;
using LearnAngular.API.Models.Domain;
using LearnAngular.API.Models.DTO;
using LearnAngular.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LearnAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductRepository _productRepository { get; }

        //Same as above, but using a read-only property
        //public readonly IProductRepository ProductRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            //Unit of Work pattern
            await _productRepository.CreateAsync(product);

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

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            //Map Domain Object to Data Transfer Object (DTO)
            var response = new List<ProductDTO>();
            foreach (var product in products)
            {
                response.Add(new ProductDTO
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
                });
            }

            return Ok(response);
        }


        //GET: api/products/{id}//
        //example: 'https://localhost:7004/api/Products/294ece55-c465-483f-3543-08ddadee43ce'
        [HttpGet]
        [Route("{id:Guid}")] //use type safety 
        public async Task<IActionResult?> GetProductById([FromRoute] Guid id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct is null)
            {
                return NotFound($"Product with id {id} not found.");
            }

            var response = new ProductDTO
            {
                Id = existingProduct.Id,
                Name = existingProduct.Name,
                Description = existingProduct.Description,
                Price = existingProduct.Price,
                ImageUrl = existingProduct.ImageUrl,
                CreatedDate = existingProduct.CreatedDate,
                UpdatedDate = existingProduct.UpdatedDate,
                IsActive = existingProduct.IsActive,
                CreatedBy = existingProduct.CreatedBy
            };

            return Ok(response);
        }
    }
}
