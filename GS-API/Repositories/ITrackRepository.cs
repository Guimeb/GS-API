using GS_csharp.Models;

namespace GS_csharp.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllAsync();
        Task<Track?> GetByIdAsync(int id);
        Task<Track?> GetByIdWithCompetencesAsync(int id);
        Task CreateAsync(Track track);
        Task UpdateAsync(Track track);
        Task DeleteAsync(int id);
    }
}