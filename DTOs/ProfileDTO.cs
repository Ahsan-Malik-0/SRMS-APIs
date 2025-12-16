namespace SRMS_APIs.DTOs
{
    public class ProfileDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Position { get; set; }
        public string? Picture { get; set; }
    }
}
