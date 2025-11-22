using GS_csharp.DTOs;
using GS_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GS_csharp.Controllers
{
    [ApiController]
    [Route("api/v1/competences")]
    public class CompetencesController : ControllerBase
    {
        private readonly ICompetenceService _competenceService;

        public CompetencesController(ICompetenceService competenceService)
        {
            _competenceService = competenceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompetences()
        {
            var competences = await _competenceService.GetAllCompetencesAsync();
            return Ok(competences);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetenceById(int id)
        {
            var competence = await _competenceService.GetCompetenceByIdAsync(id);
            if (competence == null) return NotFound("Competência não encontrada.");
            return Ok(competence);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompetence([FromBody] CompetenceCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdCompetenceDto = await _competenceService.CreateCompetenceAsync(dto);

            var newUrl = $"/api/v1/competences/{createdCompetenceDto.Id}";
            return Created(newUrl, createdCompetenceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetence(int id, [FromBody] CompetenceCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _competenceService.UpdateCompetenceAsync(id, dto);
            if (!success) return NotFound("Competência não encontrada.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetence(int id)
        {
            var success = await _competenceService.DeleteCompetenceAsync(id);
            if (!success) return NotFound("Competência não encontrada.");

            return NoContent();
        }
    }
}