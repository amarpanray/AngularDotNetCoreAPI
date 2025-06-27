using LearnAngular.API.Models.DTO;
using LearnAngular.API.Repositories.Implementation;
using LearnAngular.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
             _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            //Map Domain Object to Data Transfer Object (DTO)
            var response = new List<UserDTO>();
            foreach (var user in users)
            {
                response.Add(new UserDTO
                {
                   email = user.email,  
                   _id  = user._id,
                   name = user.name,
                });
            }

            return Ok(response);
        }
    }
}
