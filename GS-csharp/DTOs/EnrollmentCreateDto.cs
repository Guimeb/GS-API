using System.ComponentModel.DataAnnotations;

namespace GS_csharp.DTOs
{
    public class EnrollmentCreateDto
    {
        [Required(ErrorMessage = "ID do usuário é obrigatório.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "ID da trilha é obrigatório.")]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Status é obrigatório.")]
        [RegularExpression("ATIVA|CONCLUIDA|CANCELADA", ErrorMessage = "Status deve ser ATIVA, CONCLUIDA ou CANCELADA.")]
        public string Status { get; set; } = "ATIVA";
    }
}