using GS_csharp.Data;
using GS_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace GS_csharp.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments.FindAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId)
        {
            return await _context.Enrollments
                .Where(m => m.UserId == userId)
                .Include(m => m.Track)
                .ToListAsync();
        }

        public async Task<bool> IsAlreadyEnrolledAsync(int userId, int trackId)
        {
            return await _context.Enrollments
                .AnyAsync(m => m.UserId == userId && m.TrackId == trackId);
        }

        public async Task CreateAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
        }

        public async Task DeleteAsync(int id)
        {
            var enrollment = await GetByIdAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
            }
        }
    }
}