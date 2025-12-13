using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class SocietyEvents
    {
        [Key]
        public int Society_Events_Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Event_Date { get; set; }

        [StringLength(150)]
        public required string Event_Name { get; set; }

        [Required]
        public int Preplaned_Events_Requirements_Id { get; set; }

        [Required]
        public int Societies_Id { get; set; }

        public PreplanedEventsRequirements? PreplanedEventsRequirements { get; set; }
        public Societies? Societies { get; set; }
        public ICollection<EventRequisitions>? EventRequisitions { get; set; }
        public ICollection<EventAudits>? EventAudits { get; set; }
    }
}
