using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class Members
    {
        [Key]
        public int Members_Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(150)]
        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(100)]
        public required string Username { get; set; }

        [StringLength(100)]
        public required string Password { get; set; }

        [StringLength(50)]
        public required string Position { get; set; }

        [StringLength(255)]
        public string? Picture { get; set; }

        [Required]
        public int Societies_Id { get; set; }

        public Societies? Societies { get; set; }
    }
}
