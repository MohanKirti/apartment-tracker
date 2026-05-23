using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentTracker.Data.Models
{
    [Table("Expenses")]
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }

        [Required]
        [ForeignKey("CreatedBy")]
        public int CreatedByUserId { get; set; }

        [Required]
        [StringLength(200)]
        public string ExpenseName { get; set; }

        [Required]
        [StringLength(100)]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public bool IsShared { get; set; } = true;

        [Required]
        [StringLength(50)]
        public string SplitType { get; set; } = "Equal"; // Equal, Custom, Percentage

        [Required]
        [StringLength(50)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Paid, PartiallyPaid

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public virtual Apartment Apartment { get; set; }
        public virtual User CreatedBy { get; set; }

        // Navigation Properties
        public virtual ICollection<ExpenseSplit> ExpenseSplits { get; set; } = new HashSet<ExpenseSplit>();
    }
}