using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.UserRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/users/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById([FromRoute] string id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                if (!_userRepository.CheckExitsEmailAsync(user.Email))
                {
                    return BadRequest("Email da ton tai");
                }

                user.UserId = Guid.NewGuid().ToString();
                var userNew = await _userRepository.AddAsync(user);
                return Ok(userNew);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUser(string id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            try
            {
                await _userRepository.UpdateAsync(user, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            try
            {
                var userCurrent = await _userRepository.LoginUser(user);
                return Ok(userCurrent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}