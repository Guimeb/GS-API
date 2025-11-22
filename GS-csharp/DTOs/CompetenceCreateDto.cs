using System.ComponentModel.DataAnnotations;

namespace GS_csharp.DTOs
{
    public class CompetenceCreateDto
    {
        [Required(ErrorMessage = "Nome da competência é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}