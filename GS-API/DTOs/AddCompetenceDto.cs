using System.ComponentModel.DataAnnotations;

namespace GS_csharp.DTOs
{
    public class AddCompetenceDto
    {
        [Required]
        public int CompetenceId { get; set; }
    }
}