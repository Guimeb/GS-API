namespace GS_csharp.DTOs
{
    public class EnrollmentResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }

        public string TrackName { get; set; } = string.Empty;
    }
}