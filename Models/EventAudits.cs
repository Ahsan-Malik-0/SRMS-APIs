using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class EventAudits
    {
        [Key]
        public int Event_Audits_Id { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Funds_Provided { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Funds_Spent { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Revenue_Generated { get; set; }

        [Required]
        public int Society_Events_Id { get; set; }

        public SocietyEvents? SocietyEvents { get; set; }
        public ICollection<PaymentDetails>? PaymentDetails { get; set; }
    }
}
