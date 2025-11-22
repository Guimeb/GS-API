using GS_csharp.Models;
using GS_csharp.Repositories;
using GS_csharp.Data;
using GS_csharp.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GS_csharp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly AppDbContext _context;

        public UserService(IUserRepository userRepo, AppDbContext context)
        {
            _userRepo = userRepo;
            _context = context;
        }

        private UserResponseDto MapToResponseDto(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                AreaOfExpertise = user.AreaOfExpertise,
                CareerLevel = user.CareerLevel,
                RegistrationDate = user.RegistrationDate
            };
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllAsync();
            return users.Select(MapToResponseDto).ToList();
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user == null ? null : MapToResponseDto(user);
        }

        public async Task<(UserResponseDto?, string erro)> CreateUserAsync(UserCreateDto dto)
        {
            var permittedRoles = new[] { "Aluno", "Professor", "Administrador" };
            if (!permittedRoles.Contains(dto.Role))
            {
                return (null, "Role inválida. Deve ser Aluno, Professor ou Administrador.");
            }

            if (await _userRepo.GetByEmailAsync(dto.Email) != null)
            {
                return (null, "Email já cadastrado.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Role = dto.Role,
                AreaOfExpertise = dto.AreaOfExpertise,
                CareerLevel = dto.CareerLevel,
                RegistrationDate = DateTime.UtcNow
            };

            await _userRepo.CreateAsync(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return (null, $"Falha na transação do banco de dados: {ex.Message}");
            }

            return (MapToResponseDto(user), null);
        }

        public async Task<(UserResponseDto?, string erro)> UpdateUserAsync(int id, UserCreateDto dto)
        {
            var existingUser = await _userRepo.GetByIdAsync(id);
            if (existingUser == null)
            {
                return (null, "Usuário não encontrado.");
            }

            if (existingUser.Email != dto.Email && await _userRepo.GetByEmailAsync(dto.Email) != null)
            {
                return (null, "Este email já está em uso por outra conta.");
            }

            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;
            existingUser.Role = dto.Role;
            existingUser.AreaOfExpertise = dto.AreaOfExpertise;
            existingUser.CareerLevel = dto.CareerLevel;

            await _userRepo.UpdateAsync(existingUser);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return (null, "Erro de concorrência. Tente novamente.");
            }

            return (MapToResponseDto(existingUser), null);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var existingUser = await _userRepo.GetByIdAsync(id);
            if (existingUser == null) return false;

            await _userRepo.DeleteAsync(id);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}