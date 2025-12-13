using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class PaymentDetails
    {
        [Key]
        public int Payment_Details_Id { get; set; }

        [StringLength(150)]
        public required string Vendor { get; set; }

        [StringLength(150)]
        public required string Item_Description { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Paid_Amount { get; set; }

        [Required]
        public int Event_Audits_Id { get; set; }

        public EventAudits? EventAudits { get; set; }
        public ICollection<Bills>? Bills { get; set; }
    }
}
