using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class EventRequisitions
    {
        [Key]
        public int Event_Requisitions_Id { get; set; }

        [StringLength(150)]
        public required string Subject { get; set; }

        public required string Body { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Requested_Amount { get; set; }

        [Required]
        public int Society_Events_Id { get; set; }

        public SocietyEvents? SocietyEvents { get; set; }
        public ICollection<RequisitionScrutiny>? RequisitionScrutiny { get; set; }
        public ICollection<RequisitionApprovalStatus>? RequisitionApprovalStatus { get; set; }
    }
}
