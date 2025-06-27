using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LearnAngular.API.Models.Domain
{

    [Collection("users")]
    public class User
    {
        public ObjectId _id { get; set; }  
        public string? name { get; set; } 
        public string? email { get; set; } 
    }
}
