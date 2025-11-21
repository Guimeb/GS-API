namespace GS_csharp.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AreaOfExpertise { get; set; } = string.Empty;
        public string CareerLevel { get; set; } = string.Empty;
        public DateTime RegistrationDate { get; set; }
    }
}