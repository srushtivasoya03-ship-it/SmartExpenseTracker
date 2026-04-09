namespace SmartExpenseTracker.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? ReceiptUrl { get; set; }
    }
}