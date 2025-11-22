using GS_csharp.DTOs;
using GS_csharp.Models;
using System.Collections.Generic;

namespace GS_csharp.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackResponseDto>> GetAllTracksAsync();
        Task<TrackResponseDto?> GetTrackByIdAsync(int id);
        Task<TrackResponseDto> CreateTrackAsync(TrackCreateDto dto);
        Task<bool> UpdateTrackAsync(int id, TrackCreateDto dto);
        Task<bool> DeleteTrackAsync(int id);

        // Relationship Methods
        Task<IEnumerable<Competence>?> GetCompetencesByTrackIdAsync(int trackId);
        Task<(bool, string)> AddCompetenceToTrackAsync(int trackId, int competenceId);
    }
}