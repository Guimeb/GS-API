using GS_csharp.DTOs;
using GS_csharp.Models;
using GS_csharp.Repositories;
using GS_csharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GS_csharp.Services
{
    public class CompetenceService : ICompetenceService
    {
        private readonly ICompetenceRepository _competenceRepo;
        private readonly AppDbContext _context;

        public CompetenceService(ICompetenceRepository competenceRepo, AppDbContext context)
        {
            _competenceRepo = competenceRepo;
            _context = context;
        }

        private CompetenceResponseDto MapToResponseDto(Competence competence)
        {
            return new CompetenceResponseDto
            {
                Id = competence.Id,
                Name = competence.Name,
                Category = competence.Category,
                Description = competence.Description
            };
        }

        public async Task<IEnumerable<CompetenceResponseDto>> GetAllCompetencesAsync()
        {
            var competences = await _competenceRepo.GetAllAsync();
            return competences.Select(MapToResponseDto).ToList();
        }

        public async Task<CompetenceResponseDto?> GetCompetenceByIdAsync(int id)
        {
            var competence = await _competenceRepo.GetByIdAsync(id);
            return competence == null ? null : MapToResponseDto(competence);
        }

        public async Task<CompetenceResponseDto> CreateCompetenceAsync(CompetenceCreateDto dto)
        {
            var competence = new Competence
            {
                Name = dto.Name,
                Category = dto.Category,
                Description = dto.Description
            };

            await _competenceRepo.CreateAsync(competence);
            await _context.SaveChangesAsync();

            return MapToResponseDto(competence);
        }

        public async Task<bool> UpdateCompetenceAsync(int id, CompetenceCreateDto dto)
        {
            var existingCompetence = await _competenceRepo.GetByIdAsync(id);
            if (existingCompetence == null) return false;

            existingCompetence.Name = dto.Name;
            existingCompetence.Category = dto.Category;
            existingCompetence.Description = dto.Description;

            await _competenceRepo.UpdateAsync(existingCompetence);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCompetenceAsync(int id)
        {
            var existingCompetence = await _competenceRepo.GetByIdAsync(id);
            if (existingCompetence == null) return false;

            await _competenceRepo.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}