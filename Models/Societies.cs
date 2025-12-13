using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class Societies
    {
        [Key]
        public int Societies_Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [StringLength(255)]
        public string? Logo { get; set; }

        public ICollection<Members>? Members { get; set; }
        public ICollection<YearlyBudget>? YearlyBudgets { get; set; }
        public ICollection<BudgetStatus>? BudgetStatuses { get; set; }
        public ICollection<SocietyEvents>? SocietyEvents { get; set; }
    }
}
