using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace LearnAngular.API.Models.Domain
{
    [Collection("customers")]
    public class Customer
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email required")]
        public string? Email { get; set; } = string.Empty;
    }
}
