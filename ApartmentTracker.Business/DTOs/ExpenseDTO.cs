using System;
using System.Collections.Generic;

namespace ApartmentTracker.Business.DTOs
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public int ApartmentId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByName { get; set; }
        public string ExpenseName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; }
        public string SplitType { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<ExpenseSplitDTO> ExpenseSplits { get; set; } = new List<ExpenseSplitDTO>();
    }

    public class CreateExpenseDTO
    {
        public int ApartmentId { get; set; }
        public string ExpenseName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public bool IsShared { get; set; } = true;
        public string SplitType { get; set; } = "Equal";
        public List<CreateExpenseSplitDTO> ExpenseSplits { get; set; } = new List<CreateExpenseSplitDTO>();
    }

    public class UpdateExpenseDTO
    {
        public string ExpenseName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public string PaymentStatus { get; set; }
    }
}