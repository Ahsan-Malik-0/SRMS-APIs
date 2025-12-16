namespace SRMS_APIs.DTOs
{



    public class PendingEventDto
    {
        public int Society_Events_Id { get; set; }
        public DateTime Event_Date { get; set; }
        public string Event_Name { get; set; } = null!;
        public string Status { get; set; } = null!;
    }




}
