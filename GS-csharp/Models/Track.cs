using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace GS_csharp.Models
{
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Level { get; set; } // INICIANTE, INTERMEDIARIO, AVANCADO
        public string Description { get; set; }
        public int WorkloadHours { get; set; } // Carga horária
        public string MainFocus { get; set; } // IA, Dados, etc.

        // Relações N:N e 1:N (Para Serialização)
        [JsonIgnore]
        public ICollection<Competence> Competences { get; set; } = new List<Competence>();
        [JsonIgnore]
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>(); // Assumindo que Matrícula foi renomeada para Enrollment
    }
}