namespace SRMS_APIs.DTOs
{
    public class PreplanedEventsRequirementsDTO
    {
        public required string Required_Item { get; set; }
        public decimal Estimated_Price { get; set; }
        public int Preplaned_Events_Id { get; set; }
    }
}
