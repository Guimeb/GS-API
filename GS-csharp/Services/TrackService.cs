using GS_csharp.DTOs;
using GS_csharp.Models;
using GS_csharp.Repositories;
using GS_csharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GS_csharp.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepo;
        private readonly ICompetenceRepository _competenceRepo;
        private readonly AppDbContext _context;

        public TrackService(ITrackRepository trackRepo, ICompetenceRepository competenceRepo, AppDbContext context)
        {
            _trackRepo = trackRepo;
            _competenceRepo = competenceRepo;
            _context = context;
        }

        private TrackResponseDto MapToResponseDto(Track track)
        {
            return new TrackResponseDto
            {
                Id = track.Id,
                Name = track.Name,
                Level = track.Level,
                Description = track.Description,
                WorkloadHours = track.WorkloadHours,
                MainFocus = track.MainFocus
            };
        }

        public async Task<IEnumerable<TrackResponseDto>> GetAllTracksAsync()
        {
            var tracks = await _trackRepo.GetAllAsync();
            return tracks.Select(MapToResponseDto).ToList();
        }

        public async Task<TrackResponseDto?> GetTrackByIdAsync(int id)
        {
            var track = await _trackRepo.GetByIdAsync(id);
            return track == null ? null : MapToResponseDto(track);
        }

        public async Task<TrackResponseDto> CreateTrackAsync(TrackCreateDto dto)
        {
            var track = new Track
            {
                Name = dto.Name,
                Level = dto.Level,
                Description = dto.Description,
                WorkloadHours = dto.WorkloadHours,
                MainFocus = dto.MainFocus
            };

            await _trackRepo.CreateAsync(track);
            await _context.SaveChangesAsync();

            return MapToResponseDto(track);
        }

        public async Task<bool> UpdateTrackAsync(int id, TrackCreateDto dto)
        {
            var existingTrack = await _trackRepo.GetByIdAsync(id);
            if (existingTrack == null) return false;

            existingTrack.Name = dto.Name;
            existingTrack.Level = dto.Level;
            existingTrack.Description = dto.Description;
            existingTrack.WorkloadHours = dto.WorkloadHours;
            existingTrack.MainFocus = dto.MainFocus;

            await _trackRepo.UpdateAsync(existingTrack);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTrackAsync(int id)
        {
            var existingTrack = await _trackRepo.GetByIdAsync(id);
            if (existingTrack == null) return false;

            await _trackRepo.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Competence>?> GetCompetencesByTrackIdAsync(int trackId)
        {
            var track = await _trackRepo.GetByIdWithCompetencesAsync(trackId);
            return track?.Competences;
        }

        public async Task<(bool, string)> AddCompetenceToTrackAsync(int trackId, int competenceId)
        {
            var track = await _trackRepo.GetByIdWithCompetencesAsync(trackId);
            if (track == null)
            {
                return (false, "Trilha não encontrada.");
            }

            var competence = await _competenceRepo.GetByIdAsync(competenceId);
            if (competence == null)
            {
                return (false, "Competência não encontrada.");
            }

            if (track.Competences.Any(c => c.Id == competenceId))
            {
                return (false, "Competência já associada a esta trilha.");
            }

            track.Competences.Add(competence);
            await _trackRepo.UpdateAsync(track);
            await _context.SaveChangesAsync();

            return (true, string.Empty);
        }
    }
}