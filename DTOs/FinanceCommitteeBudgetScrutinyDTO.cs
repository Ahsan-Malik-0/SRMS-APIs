namespace SRMS_APIs.DTOs
{
    public class FinanceCommitteeBudgetScrutinyDTO
    {
        public string? Comments { get; set; }
        public required string Status { get; set; }
        public DateTime Date { get; set; }
        public int Finance_Committee_Id { get; set; }
        public int Yearly_Budget_Id { get; set; }
    }
}
