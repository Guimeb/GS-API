using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace GS_csharp.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int TrackId { get; set; }

        [JsonIgnore]
        public User? User { get; set; } // Deve ser 'User' (singular)
        [JsonIgnore]
        public Track? Track { get; set; } // Deve ser 'Track' (singular)

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; } = "ATIVA";
    }
}