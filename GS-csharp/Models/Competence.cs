using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GS_csharp.Models
{
    public class Competence
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }
        public string Description { get; set; }

        // Relação N:N com Tracks (Trilhas)
        [JsonIgnore]
        public ICollection<Track> Tracks { get; set; } = new List<Track>();
    }
}