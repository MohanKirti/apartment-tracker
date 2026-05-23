using System;
using System.Collections.Generic;
using ApartmentTracker.Business.DTOs;

namespace ApartmentTracker.Business.Services
{
    /// <summary>
    /// Service interface for managing expenses
    /// </summary>
    public interface IExpenseService
    {
        // Retrieve operations
        ExpenseDTO GetExpenseById(int expenseId);
        List<ExpenseDTO> GetExpensesByApartment(int apartmentId);
        List<ExpenseDTO> GetExpensesByApartmentAndDate(int apartmentId, DateTime startDate, DateTime endDate);
        List<ExpenseDTO> GetExpensesByCategory(int apartmentId, string category);
        List<ExpenseDTO> GetExpensesByResident(int residentId, int apartmentId);

        // Create operations
        ExpenseDTO CreateExpense(CreateExpenseDTO createExpenseDTO, int userId);
        ExpenseDTO CreateExpenseWithCustomSplits(CreateExpenseDTO createExpenseDTO, int userId);

        // Update operations
        ExpenseDTO UpdateExpense(int expenseId, UpdateExpenseDTO updateExpenseDTO, int userId);
        ExpenseDTO UpdateExpensePaymentStatus(int expenseId, string paymentStatus);

        // Delete operations
        bool DeleteExpense(int expenseId);

        // Analysis and summary
        ExpenseSummaryDTO GetExpenseSummary(int apartmentId, int month, int year);
        ResidentPaymentSummaryDTO GetResidentPaymentSummary(int residentId, int apartmentId);
        decimal GetTotalExpensesForApartment(int apartmentId);
        decimal GetMonthlyExpensesForApartment(int apartmentId, int month, int year);

        // Expense splitting
        List<ExpenseSplitDTO> CalculateEqualSplits(decimal totalAmount, int numResidents);
        List<ExpenseSplitDTO> CalculatePercentageSplits(decimal totalAmount, List<decimal> percentages);
        List<ExpenseSplitDTO> CalculateCustomSplits(decimal totalAmount, List<decimal> customAmounts);
    }

    /// <summary>
    /// DTO for expense summary information
    /// </summary>
    public class ExpenseSummaryDTO
    {
        public int ApartmentId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalExpenses { get; set; }
        public Dictionary<string, decimal> ExpensesByCategory { get; set; }
        public Dictionary<string, decimal> ExpensesByResident { get; set; }
        public decimal AverageExpensePerResident { get; set; }
        public int TotalTransactions { get; set; }
    }

    /// <summary>
    /// DTO for resident payment summary
    /// </summary>
    public class ResidentPaymentSummaryDTO
    {
        public int ResidentId { get; set; }
        public string ResidentName { get; set; }
        public decimal TotalOwed { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalPending { get; set; }
        public int PendingTransactions { get; set; }
        public DateTime? LastPaymentDate { get; set; }
    }
}