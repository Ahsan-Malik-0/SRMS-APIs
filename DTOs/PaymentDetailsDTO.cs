namespace SRMS_APIs.DTOs
{
    public class PaymentDetailsDTO
    {
        public required string Vendor { get; set; }
        public required string Item_Description { get; set; }
        public decimal Paid_Amount { get; set; }
        public int Event_Audits_Id { get; set; }
    }
}
