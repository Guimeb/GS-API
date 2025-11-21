using GS_csharp.DTOs;
using GS_csharp.Models;
using GS_csharp.Repositories;
using GS_csharp.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GS_csharp.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepo;
        private readonly IUserRepository _userRepo;
        private readonly ITrackRepository _trackRepo;
        private readonly AppDbContext _context;

        public EnrollmentService(IEnrollmentRepository enrollmentRepo, IUserRepository userRepo, ITrackRepository trackRepo, AppDbContext context)
        {
            _enrollmentRepo = enrollmentRepo;
            _userRepo = userRepo;
            _trackRepo = trackRepo;
            _context = context;
        }

        private EnrollmentResponseDto MapToResponseDto(Enrollment enrollment)
        {
            return new EnrollmentResponseDto
            {
                Id = enrollment.Id,
                UserId = enrollment.UserId,
                TrackId = enrollment.TrackId,
                Status = enrollment.Status,
                EnrollmentDate = enrollment.EnrollmentDate,
                TrackName = enrollment.Track != null ? enrollment.Track.Name : "Trilha Removida"
            };
        }

        public async Task<(EnrollmentResponseDto?, string error)> CreateEnrollmentAsync(EnrollmentCreateDto dto)
        {
            if (await _userRepo.GetByIdAsync(dto.UserId) == null)
                return (null, "Usuário não encontrado.");

            if (await _trackRepo.GetByIdAsync(dto.TrackId) == null)
                return (null, "Trilha não encontrada.");

            if (await _enrollmentRepo.IsAlreadyEnrolledAsync(dto.UserId, dto.TrackId))
                return (null, "Usuário já matriculado nesta trilha.");

            var enrollment = new Enrollment
            {
                UserId = dto.UserId,
                TrackId = dto.TrackId,
                Status = dto.Status,
                EnrollmentDate = DateTime.UtcNow
            };

            await _enrollmentRepo.CreateAsync(enrollment);
            await _context.SaveChangesAsync();

            var createdEnrollment = await _enrollmentRepo.GetByIdAsync(enrollment.Id);

            return (MapToResponseDto(createdEnrollment!), string.Empty);
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            var existingEnrollment = await _enrollmentRepo.GetByIdAsync(id);
            if (existingEnrollment == null) return false;

            await _enrollmentRepo.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<EnrollmentResponseDto>?> GetEnrollmentsByUserIdAsync(int userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var enrollments = await _enrollmentRepo.GetByUserIdAsync(userId);

            return enrollments.Select(MapToResponseDto).ToList();
        }
    }
}