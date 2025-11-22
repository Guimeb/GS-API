using GS_csharp.DTOs;
using GS_csharp.Models;
using System.Collections.Generic;

namespace GS_csharp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(int id);

        Task<(UserResponseDto?, string erro)> CreateUserAsync(UserCreateDto dto);
        Task<(UserResponseDto?, string erro)> UpdateUserAsync(int id, UserCreateDto dto);

        Task<bool> DeleteUserAsync(int id);
    }
}