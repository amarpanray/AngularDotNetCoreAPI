using System.ComponentModel.DataAnnotations;

namespace LearnAngular.API.Models.DTO
{
    public class UpdateProductRequestDTO
    {
        [Required(ErrorMessage = "Valid GUID required for update operation.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name not provided.")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;  
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public Guid CreatedBy { get; set; }
    }
}
