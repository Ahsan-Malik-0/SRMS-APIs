namespace SRMS_APIs.DTOs
{
    public class EventRequisitionsDTO
    {
        public required string Subject { get; set; }
        public required string Body { get; set; }
        public decimal Requested_Amount { get; set; }
        public int Society_Events_Id { get; set; }
    }
}
