using System.ComponentModel.DataAnnotations;

namespace GS_csharp.DTOs
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Role é obrigatória.")]
        [RegularExpression("Aluno|Professor|Administrador", ErrorMessage = "Role inválida. Deve ser Aluno, Professor ou Administrador.")]
        public string Role { get; set; } = "Aluno";

        public string AreaOfExpertise { get; set; } = string.Empty;
        public string CareerLevel { get; set; } = string.Empty;
    }
}