using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class Bills
    {
        [Key]
        public int Bills_Id { get; set; }

        [StringLength(255)]
        public string? Picture { get; set; }

        [Required]
        public int Payment_Details_Id { get; set; }

        public PaymentDetails? PaymentDetails { get; set; }
    }
}
