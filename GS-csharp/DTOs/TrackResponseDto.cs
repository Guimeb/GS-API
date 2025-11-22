namespace GS_csharp.DTOs
{
    public class TrackResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int WorkloadHours { get; set; }
        public string MainFocus { get; set; } = string.Empty;
    }
}