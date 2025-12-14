namespace SRMS_APIs.DTOs
{
    public class RequisitionScrutinyDTO
    {
        public required string Approval_Status { get; set; }
        public string? Comments { get; set; }
        public DateTime Date { get; set; }
        public int Finance_Committee_Id { get; set; }
        public int Event_Requisitions_Id { get; set; }
    }
}
