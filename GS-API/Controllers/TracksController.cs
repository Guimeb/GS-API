using GS_csharp.DTOs;
using GS_csharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GS_csharp.Controllers
{
    [ApiController]
    [Route("api/v1/tracks")]
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTracks()
        {
            var tracks = await _trackService.GetAllTracksAsync();
            return Ok(tracks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackById(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);
            if (track == null) return NotFound("Trilha não encontrada.");
            return Ok(track);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrack([FromBody] TrackCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdTrackDto = await _trackService.CreateTrackAsync(dto);

            var newUrl = $"/api/v1/tracks/{createdTrackDto.Id}";
            return Created(newUrl, createdTrackDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrack(int id, [FromBody] TrackCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await _trackService.UpdateTrackAsync(id, dto);
            if (!success) return NotFound("Trilha não encontrada.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var success = await _trackService.DeleteTrackAsync(id);
            if (!success) return NotFound("Trilha não encontrada.");

            return NoContent();
        }

        [HttpGet("{trackId}/competences")]
        public async Task<IActionResult> GetCompetencesByTrackId(int trackId)
        {
            var competences = await _trackService.GetCompetencesByTrackIdAsync(trackId);
            if (competences == null)
            {
                return NotFound("Trilha não encontrada.");
            }
            return Ok(competences);
        }

        [HttpPost("{trackId}/competences")]
        public async Task<IActionResult> AddCompetenceToTrack(int trackId, [FromBody] AddCompetenceDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var (success, error) = await _trackService.AddCompetenceToTrackAsync(trackId, dto.CompetenceId);

            if (!success)
            {
                return BadRequest(error);
            }

            return Ok("Competência adicionada com sucesso.");
        }
    }
}