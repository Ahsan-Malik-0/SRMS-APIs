using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class YearlyBudget
    {
        [Key]
        public int Yearly_Budget_Id { get; set; }

        [StringLength(50)]
        public required string Session { get; set; }

        [DataType(DataType.Date)]
        public required DateTime Submitted_Date { get; set; }

        [Required]
        public int Societies_Id { get; set; }

        public Societies? Societies { get; set; }
        public ICollection<PreplanedEvents>? PreplanedEvents { get; set; }
        public ICollection<FinanceCommitteeBudgetScrutiny>? FinanceCommitteeBudgetScrutiny { get; set; }
        public ICollection<BudgetStatus>? BudgetStatuses { get; set; }
    }
}
