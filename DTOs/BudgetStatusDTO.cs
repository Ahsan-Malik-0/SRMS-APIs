namespace SRMS_APIs.DTOs
{
    public class BudgetStatusDTO
    {
        public decimal Requested_Amount { get; set; }
        public decimal Allocated_Budget { get; set; }
        public int Societies_Id { get; set; }
        public int Yearly_Budget_Id { get; set; }
    }
}
