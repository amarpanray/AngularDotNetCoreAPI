using LearnAngular.API.Models.DTO;
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

        //POST: api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Map Domain Object to Data Transfer Object (DTO)
            var user = new Models.Domain.User
            {
                email = request.email,
                name = request.name,
            };
            //Abstracting this task to the repository layer
            //Unit of Work pattern
            var savedUser = await _userRepository.CreateAsync(user);
            //Map DTO back to Domain Object
            var response = new UserDTO
            {
                id = savedUser._id,
                email = savedUser.email,
                name = savedUser.name,
            };
            return CreatedAtAction(nameof(GetAllUsers), new { id = response.id }, response);
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
                   id  = user._id,
                   name = user.name,
                });
            }

            return Ok(response);
        }
    }
}
