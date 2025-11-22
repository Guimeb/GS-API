using GS_csharp.DTOs;
using GS_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GS_csharp.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("enrollments")]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (enrollmentDto, error) = await _enrollmentService.CreateEnrollmentAsync(dto);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }


            var newUrl = $"/api/v1/enrollments/{enrollmentDto.Id}";
            return Created(newUrl, enrollmentDto);
        }

        [HttpGet("users/{userId}/enrollments")]
        public async Task<IActionResult> GetEnrollmentsByUserId(int userId)
        {
            var enrollments = await _enrollmentService.GetEnrollmentsByUserIdAsync(userId);

            if (enrollments == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(enrollments);
        }

        [HttpDelete("enrollments/{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var success = await _enrollmentService.DeleteEnrollmentAsync(id);
            if (!success)
            {
                return NotFound("Matrícula não encontrada.");
            }
            return NoContent();
        }
    }
}