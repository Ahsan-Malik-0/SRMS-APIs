namespace SRMS_APIs.DTOs
{
    public class RequisitionApprovalStatusDTO
    {
        public required string Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Allocated_Amount { get; set; }
        public int Finance_Committee_Id { get; set; }
        public int Event_Requisitions_Id { get; set; }
    }
}
