using GS_csharp.Services;
using GS_csharp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GS_csharp.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (createdUserDto, erro) = await _userService.CreateUserAsync(dto);

            if (!string.IsNullOrEmpty(erro))
            {
                return BadRequest(erro);
            }

            var newUrl = $"/api/v1/users/{createdUserDto!.Id}";

            // Retorna 201 Created apenas com o ID, como forma mais robusta de resposta.
            return Created(newUrl, new { id = createdUserDto.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (userDto, erro) = await _userService.UpdateUserAsync(id, dto);

            if (!string.IsNullOrEmpty(erro))
            {
                if (erro == "Usuário não encontrado.")
                    return NotFound(erro);

                return BadRequest(erro);
            }

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound("Usuário não encontrado.");
            }
            return NoContent();
        }
    }
}