using GS_csharp.DTOs;
using GS_csharp.Models;
using System.Collections.Generic;

namespace GS_csharp.Services
{
    public interface IEnrollmentService
    {
        Task<(EnrollmentResponseDto?, string error)> CreateEnrollmentAsync(EnrollmentCreateDto dto);
        Task<bool> DeleteEnrollmentAsync(int id);
        Task<IEnumerable<EnrollmentResponseDto>?> GetEnrollmentsByUserIdAsync(int userId);
    }
}