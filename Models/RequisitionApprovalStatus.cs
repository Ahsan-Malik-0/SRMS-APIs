using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class RequisitionApprovalStatus
    {
        [Key]
        public int Requisition_Approval_Status_Id { get; set; }

        [StringLength(50)]
        public required string Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Allocated_Amount { get; set; }

        [Required]
        public int Finance_Committee_Id { get; set; }

        [Required]
        public int Event_Requisitions_Id { get; set; }

        public FinanceCommittee? FinanceCommittee { get; set; }
        public EventRequisitions? EventRequisitions { get; set; }
    }
}
