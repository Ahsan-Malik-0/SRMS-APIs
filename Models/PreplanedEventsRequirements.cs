using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class PreplanedEventsRequirements
    {
        [Key]
        public int Preplaned_Events_Requirements_Id { get; set; }

        [StringLength(150)]
        public required string Required_Item { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Estimated_Price { get; set; }

        [Required]
        public int Preplaned_Events_Id { get; set; }

        public PreplanedEvents? PreplanedEvents { get; set; }
    }
}
