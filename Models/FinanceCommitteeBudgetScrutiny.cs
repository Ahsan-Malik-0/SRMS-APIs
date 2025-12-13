using System.ComponentModel.DataAnnotations;

namespace SRMS_APIs.Models
{
    public class FinanceCommitteeBudgetScrutiny
    {
        [Key]
        public int Finance_Committee_Budget_Scrutiny_Id { get; set; }

        public string? Comments { get; set; }

        [StringLength(50)]
        public required string Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int Finance_Committee_Id { get; set; }

        [Required]
        public int Yearly_Budget_Id { get; set; }

        public FinanceCommittee? FinanceCommittee { get; set; }
        public YearlyBudget? YearlyBudget { get; set; }
    }
}
