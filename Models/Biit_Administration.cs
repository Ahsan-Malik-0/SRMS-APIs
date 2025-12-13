using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class Biit_Administration
    {
        public class BiitAdministration
        {
            [Key]
            public int Administration_Id { get; set; }

            [Required]
            [StringLength(100)]
            public required string Name { get; set; }

            [Required]
            [StringLength(150)]
            [EmailAddress]
            public required string Email { get; set; }

            [Required]
            [StringLength(100)]
            public required string Username { get; set; }

            [Required]
            [StringLength(100)]
            public required string Password { get; set; }

            [Required]
            [StringLength(50)]
            public required string Role { get; set; }

            [StringLength(255)]
            public string? Picture { get; set; }
        }
    }
}
