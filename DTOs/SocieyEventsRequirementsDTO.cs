namespace SRMS_APIs.DTOs
{
    public class SocieyEventsRequirementsDTO
    {
        public required string Item_Type { get; set; }
        public required string Item_Name { get; set; }
        public decimal Estimated_Price { get; set; }
        public int Quantity { get; set; }
    }
}
