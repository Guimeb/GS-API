using GS_csharp.DTOs;
using System.Collections.Generic;

namespace GS_csharp.Services
{
    public interface ICompetenceService
    {
        Task<IEnumerable<CompetenceResponseDto>> GetAllCompetencesAsync();
        Task<CompetenceResponseDto?> GetCompetenceByIdAsync(int id);

        Task<CompetenceResponseDto> CreateCompetenceAsync(CompetenceCreateDto dto);

        Task<bool> UpdateCompetenceAsync(int id, CompetenceCreateDto dto);
        Task<bool> DeleteCompetenceAsync(int id);
    }
}