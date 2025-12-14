namespace SRMS_APIs.DTOs
{
    public class SocietyEventsDTO
    {
        public DateTime Event_Date { get; set; }
        public required string Event_Name { get; set; }
        public int Preplaned_Events_Requirements_Id { get; set; }
        public int Societies_Id { get; set; }
    }
}
