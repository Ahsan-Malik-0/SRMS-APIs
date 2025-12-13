using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class SocieyEventsRequirements
    {
        [Key]
        public int Sociey_Events_Requirements_Id { get; set; }

        [StringLength(150)]
        public required string Item_Type { get; set; }

        [StringLength(150)]
        public required string Item_Name { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Estimated_Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
