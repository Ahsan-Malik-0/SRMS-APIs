namespace SRMS_APIs.DTOs
{
    public class YearlyBudgetDTO
    {
        public required string Session { get; set; }
        public DateTime Submitted_Date { get; set; }
        public int Societies_Id { get; set; }
    }
}
