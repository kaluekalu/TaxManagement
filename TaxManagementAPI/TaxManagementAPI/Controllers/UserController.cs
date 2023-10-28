using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Core.Dto;
using TaskManagementAPI.Core.Services;
using TaskManagementAPI.Model.Entities;

namespace TaxManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool createdUser = await _userRepository.CreateUserAsync(userDto);

            if (createdUser)
            {
                return Ok("User Created Successfully");
            }
            else
            {
                return BadRequest("User with same Email Exists");
            }            
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string UserId)
        {
            var fetchUser = await _userRepository.ReadUserAsync(UserId);

            if (fetchUser == null)
            {
                return NotFound("User Not Existent");
            }

            return Ok(fetchUser);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var deletedUser = await _userRepository.DeleteUserAsync(userId);

            if (!deletedUser)
            {
                return NotFound($"User with Id {userId} Not found");
            }
            else
            {
                return Ok("Successfully Deleted");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var allUsers = await _userRepository.ReadAllUsersAsync();
            return Ok(allUsers);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserRecord(string userId, UserDto updatedUserDto)
        {
            var result = await _userRepository.UpdateUserAsync(userId, updatedUserDto);

            if (!result)
            {
                return NotFound($"User with Id { userId } Not found or User already Exists");
            }

            return Ok("Updated User Details Successfully");
        }
    }
}
