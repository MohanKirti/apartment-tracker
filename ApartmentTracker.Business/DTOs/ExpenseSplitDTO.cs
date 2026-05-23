using System;

namespace ApartmentTracker.Business.DTOs
{
    public class ExpenseSplitDTO
    {
        public int SplitId { get; set; }
        public int ExpenseId { get; set; }
        public int ResidentUserId { get; set; }
        public string ResidentName { get; set; }
        public decimal SplitAmount { get; set; }
        public decimal? SplitPercentage { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime? PaidDate { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class CreateExpenseSplitDTO
    {
        public int ResidentUserId { get; set; }
        public decimal SplitAmount { get; set; }
        public decimal? SplitPercentage { get; set; }
    }

    public class UpdateExpenseSplitDTO
    {
        public string PaymentStatus { get; set; }
        public DateTime? PaidDate { get; set; }
        public string PaymentMethod { get; set; }
    }
}