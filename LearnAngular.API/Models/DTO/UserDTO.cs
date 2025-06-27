using MongoDB.Bson;

namespace LearnAngular.API.Models.DTO
{
    public class UserDTO
    {
        public ObjectId _id { get; set; } 
        public string? name { get; set; } 
        public string? email { get; set; }  
    }
}
