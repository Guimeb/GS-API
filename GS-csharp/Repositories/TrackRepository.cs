using GS_csharp.Data;
using GS_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace GS_csharp.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly AppDbContext _context;

        public TrackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks.ToListAsync();
        }

        public async Task<Track?> GetByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task<Track?> GetByIdWithCompetencesAsync(int id)
        {
            return await _context.Tracks
                .Include(t => t.Competences)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
        }

        public async Task UpdateAsync(Track track)
        {
            _context.Entry(track).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var track = await GetByIdAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
            }
        }
    }
}