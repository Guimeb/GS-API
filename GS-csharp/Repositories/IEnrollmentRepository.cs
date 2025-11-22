using GS_csharp.Models;

namespace GS_csharp.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetByIdAsync(int id);
        Task<IEnumerable<Enrollment>> GetByUserIdAsync(int userId);
        Task<bool> IsAlreadyEnrolledAsync(int userId, int trackId);
        Task CreateAsync(Enrollment enrollment);
        Task DeleteAsync(int id);
    }
}