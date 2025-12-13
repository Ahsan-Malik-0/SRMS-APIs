using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class RequisitionScrutiny
    {
        [Key]
        public int Requisition_Scrutiny_Id { get; set; }

        [StringLength(50)]
        public required string Approval_Status { get; set; }

        public string? Comments { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int Finance_Committee_Id { get; set; }

        [Required]
        public int Event_Requisitions_Id { get; set; }

        public FinanceCommittee? FinanceCommittee { get; set; }
        public EventRequisitions? EventRequisitions { get; set; }
    }
}
