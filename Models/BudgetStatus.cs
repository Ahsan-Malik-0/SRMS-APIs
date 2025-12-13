using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class BudgetStatus
    {
        [Key]
        public int Budget_Status_Id { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Requested_Amount { get; set; }

        [Required]
        [Range(0, 9999999999.99)]
        public decimal Allocated_Budget { get; set; }

        [Required]
        public int Societies_Id { get; set; }

        [Required]
        public int Yearly_Budget_Id { get; set; }

        public Societies? Societies { get; set; }
        public YearlyBudget? YearlyBudget { get; set; }
    }
}
