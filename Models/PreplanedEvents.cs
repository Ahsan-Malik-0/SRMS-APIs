using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class PreplanedEvents
    {
        [Key]
        public int Preplaned_Events_Id { get; set; }

        [StringLength(150)]
        public required string Event_Name { get; set; }

        [Required]
        public int Yearly_Budget_Id { get; set; }

        public YearlyBudget? YearlyBudget { get; set; }
        public ICollection<PreplanedEventsRequirements>? PreplanedEventsRequirements { get; set; }
    }
}
