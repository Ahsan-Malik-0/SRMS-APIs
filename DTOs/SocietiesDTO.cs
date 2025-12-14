namespace SRMS_APIs.DTOs
{
    public class SocietiesDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Logo { get; set; }
    }
}
