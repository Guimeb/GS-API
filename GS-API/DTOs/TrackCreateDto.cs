using System.ComponentModel.DataAnnotations;

namespace GS_csharp.DTOs
{
    public class TrackCreateDto
    {
        [Required(ErrorMessage = "Nome da trilha é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nível é obrigatório.")]
        [RegularExpression("INICIANTE|INTERMEDIARIO|AVANCADO", ErrorMessage = "Nível deve ser INICIANTE, INTERMEDIARIO ou AVANCADO.")]
        public string Level { get; set; } = "INICIANTE";

        public string Description { get; set; } = string.Empty;

        [Range(1, 999, ErrorMessage = "A carga horária deve ser positiva.")]
        public int WorkloadHours { get; set; }

        public string MainFocus { get; set; } = string.Empty;
    }
}