namespace SRMS_APIs.DTOs
{
    public class CreateEventDto
    {
        public DateTime Event_Date { get; set; }
        public string Event_Name { get; set; } = null!;
        public int Societies_Id { get; set; }
        public List<EventRequirementDto> Requirements { get; set; } = new();
    }

    public class UpdateEventDto
    {
        public DateTime Event_Date { get; set; }
        public string Event_Name { get; set; } = null!;
        public int Societies_Id { get; set; }
        public List<EventRequirementDto> Requirements { get; set; } = new();
    }

    public class EventRequirementDto
    {
        public string Item_Type { get; set; } = null!;
        public string Item_Name { get; set; } = null!;
        public decimal Estimated_Price { get; set; }
        public int Quantity { get; set; }
    }
}
